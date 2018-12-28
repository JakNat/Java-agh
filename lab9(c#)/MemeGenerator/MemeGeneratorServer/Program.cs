﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Autofac;
using MemeGenerator.Model;
using MemeGenerator.Models;
using MemeGeneratorDataAccess;
using MemeGeneratorServer.DAL;
using MemeGeneratorServer.Services;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;

namespace MemeGeneratorServer
{
    class Program
    {
        private static IContainer Container { get; set; }
        private static readonly MemeRepository _memeRepository = new MemeRepository(new MemeGeneratorDBContext());

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType<ConsoleOutput>().As<IOutput>();
            //builder.RegisterType<TodayWriter>().As<IDateWriter>();
            Container = builder.Build();

            //Trigger the method SetMeme when a packet of type 'Meme' is received
            //We expect the incoming object to be a meme which we state explicitly by using <meme>
            NetworkComms.AppendGlobalIncomingPacketHandler<ImageWrapper>("Meme", SetMeme);

            NetworkComms.AppendGlobalIncomingPacketHandler<LoginDto>("Login", UserService.Login);

            NetworkComms.AppendGlobalIncomingPacketHandler<RegisterDto>("Register", UserService.Register);

            //Start listening for incoming connections
            Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 12345));
 
            //Print out the IPs and ports we are now listening on
            Console.WriteLine("Server listening for TCP connection on:");
            foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
                Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);
 
            //Let the user close the server
            Console.WriteLine("\nPress any key to close server.");
            Console.ReadKey(true);
 
            //We have used NetworkComms so we should ensure that we correctly call shutdown
            NetworkComms.Shutdown();
        }

        private static void Register(PacketHeader packetHeader, Connection connection, RegisterDto incomingObject)
        {
            throw new NotImplementedException();
        }

       
        /// <summary>
        /// Writes the provided message to the console window
        /// </summary>
        /// <param name="header">The packet header associated with the incoming message</param>
        /// <param name="connection">The connection used by the incoming message</param>
        /// <param name="message">The message to be printed to the console</param>

        private static void SetMeme(PacketHeader header, Connection connection, ImageWrapper message)
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