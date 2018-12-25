using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using MemeGenerator.Model;
using MemeGenerator.Models;
using MemeGeneratorDataAccess;
using MemeGeneratorServer.DAL;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
 
namespace MemeGeneratorServer
{
    class Program
    {
        private static readonly MemeRepository _memeRepository = new MemeRepository(new MemeGeneratorDBContext());

        static void Main(string[] args)
        {
            //Trigger the method SetMeme when a packet of type 'Meme' is received
            //We expect the incoming object to be a meme which we state explicitly by using <meme>
            NetworkComms.AppendGlobalIncomingPacketHandler<MemeDto>("Meme", SetMeme);


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
 
        /// <summary>
        /// Writes the provided message to the console window
        /// </summary>
        /// <param name="header">The packet header associated with the incoming message</param>
        /// <param name="connection">The connection used by the incoming message</param>
        /// <param name="message">The message to be printed to the console</param>
      
        private static void SetMeme(PacketHeader header, Connection connection, MemeDto message)
        {
            Meme meme = new Meme()
            {
                Content = message.ImgByte,
                CreatedDate = DateTime.Now,
                MemeTitle = message.TopText.Take(3).ToString()
            };
            _memeRepository.Add(meme);
            Console.WriteLine("\nImage bytes: " + message.ImgByte);
            _memeRepository.SaveAsync();
            PutText(message);

        }
        private static void PutText(MemeDto message)
        {
           // BitmapImage bitmap = ToImage(ImgBytes);

            Bitmap bitmap;
            using (var ms = new MemoryStream(message.ImgByte))
            {
                bitmap = new Bitmap(ms);
            }



            string firstText = message.TopText;
            string secondText = message.BottomText;

            PointF firstLocation = new PointF(10f, 10f);
            PointF secondLocation = new PointF(10f, 90f);

          //  Bitmap bitmap2 = BitmapImage2Bitmap(bitmap);//load the image file


            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Impact", 30))
                {
                    graphics.DrawString(firstText, arialFont, Brushes.White, firstLocation);
                    graphics.DrawString(secondText, arialFont, Brushes.White, secondLocation);
                }
            }
            bitmap.Save(AppDomain.CurrentDomain.BaseDirectory);
        }
        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }
        public BitmapImage ToImage(byte[] array)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new System.IO.MemoryStream(array);
            image.EndInit();
            return image;
        }
    }
}