using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using MemeGenerator.Model;
using MemeGenerator.Models;
using MemeGeneratorDataAccess;
using MemeGeneratorServer.DAL;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;

namespace MemeGeneratorServer.Services
{
    public static class MemeService
    {
        private static readonly MemeRepository _memeRepository = new MemeRepository(new MemeGeneratorDBContext());

        /// <summary>
        /// Writes the provided message to the console window
        /// </summary>
        /// <param name="header">The packet header associated with the incoming message</param>
        /// <param name="connection">The connection used by the incoming message</param>
        /// <param name="message">The message to be printed to the console</param>

        public static void SetMeme(PacketHeader header, Connection connection, ImageWrapper message)
        {
            var memeContent = GenerateMeme(message);

            Meme meme = new Meme()
            {
                Content = imageToByteArray(memeContent),
                CreatedDate = DateTime.Now,
                MemeTitle = message.ImageName
            };

            try
            {
                _memeRepository.Add(meme);
                _memeRepository.SaveAsync();
                Console.WriteLine("\nNew meme added to database:\n" +
                    "Meme title: " + meme.MemeTitle +
                    "\nCreated by id: " + meme.CreatedById);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError :( \nmessage:  " + ex.Message);
            }


        }

        private static Image GenerateMeme(ImageWrapper message)
        {
            string firstText = message.TopText;
            string secondText = message.BottomText;
            var image = message.Image;

            RectangleF TopSize = new RectangleF(new Point(0, 0), new SizeF(image.Width, image.Height / 8));
            int y = (int)(image.Height * (7.0 / 8.0));
            RectangleF BottomSize = new RectangleF(new Point(0, y), new SizeF(image.Width, image.Height / 8));

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            using (Graphics graphics = Graphics.FromImage(message.Image))
            {
                using (Font arialFont = new Font("Impact", image.Height / (14 / 1), FontStyle.Bold, GraphicsUnit.Point))
                {
                    graphics.DrawString(firstText, arialFont, Brushes.White, TopSize, format);
                    graphics.DrawString(secondText, arialFont, Brushes.White, BottomSize, format);
                }
            }
            var path = AppDomain.CurrentDomain.BaseDirectory + "test.jpg";
            message.Image.Save(path);
            return message.Image;
        }

        public static byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }
    }
}