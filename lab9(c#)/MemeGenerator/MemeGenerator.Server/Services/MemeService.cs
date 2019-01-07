using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using MemeGenerator.Model.Type;
using MemeGenerator.Model.Dto;
using MemeGenerator.DataAccessLayer;
using MemeGenerator.DataAccessLayer.Repositories;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using MemeGenerator.Model;
using System.Linq;

namespace MemeGenerator.Client.Server.Services
{
    public class MemeService : IMemeService
    {
        private readonly IGenericRepository<Meme> memeRepository;

        public MemeService(IGenericRepository<Meme> memeRepository)
        {
            this.memeRepository = memeRepository;
        }

        /// <summary>
        /// Generete new meme by a server and add to a database
        /// </summary>
        public async void GenerateMemeRequest(PacketHeader header, Connection connection, MemeDto message)
        {
            var memeContent = GenerateMeme(message);
            var memes = memeRepository.Include(x => x.User).Where(x => x.User.UserName == "user");

            Meme meme = new Meme()
            {
                Content = imageToByteArray(memeContent),
                CreatedDate = DateTime.Now,
                MemeTitle = message.ImageName
            };

            try
            {
                memeRepository.Add(meme);
                await memeRepository.SaveAsync();
                //Console.WriteLine("\nNew meme added to database:\n" +
                //    "Meme title: " + meme.MemeTitle +
                //    "\nCreated by id: " + meme.CreatedById);
                connection.SendObject(PacketType.CreateMemeResponse, "Meme added.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError :( \nmessage:  " + ex.Message);
                connection.SendObject(PacketType.CreateMemeResponse, "Error ocured.");
            }
        }

        public void GetMemesByUSerRequest(PacketHeader packetHeader, Connection connection, string incomingObject)
        {
            var memes = memeRepository.Include(x => x.User).Where(x => x.User.UserName == incomingObject);

        }
        private Image GenerateMeme(MemeDto message)
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

        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }

    }
}