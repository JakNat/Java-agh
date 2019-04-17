using System;
using MemeGenerator.Model.Type;
using MemeGenerator.Model.Dto;
using MemeGenerator.DataAccessLayer;
using MemeGenerator.DataAccessLayer.Repositories;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using MemeGenerator.Model;
using System.Linq;
using MemeGeneratorServer;
using MemeGenerator.Server.Utils;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using MemeGenerator.Model.Responses;

namespace MemeGenerator.Client.Server.Services
{
    public class MemeService : IMemeService
    {
        private readonly IGenericRepository<Meme> memeRepository;
        private readonly DummyAuthentication dummyAuthentication;

        public MemeService(IGenericRepository<Meme> memeRepository, DummyAuthentication dummyAuthentication)
        {
            this.memeRepository = memeRepository;
            this.dummyAuthentication = dummyAuthentication;
        }

        public async void GenerateMemeRequest(PacketHeader header, Connection connection, string message)
        {
         
        }
        /// <summary>
        /// Generete new meme by a server and add to a database
        /// </summary>
        public async void GenerateMemeRequest(PacketHeader header, Connection connection, MemeDto message)
        {
            var key = message.Key;
            var userId = dummyAuthentication.LoggedUsers[key];
            var memeContent = MemeBuilder.GenerateMeme(message);
            Meme meme = new Meme()
            {
                Content = imageToByteArray(memeContent),
                CreatedDate = DateTime.Now,
                UserId = userId,
                Title = message.ImageName
            };

            try
            {
                memeRepository.Add(meme);
                await memeRepository.SaveAsync();
                connection.SendObject(PacketTypes.CreateMeme.Response, ResponseMessage.MemeAdded);

            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError :( \nmessage:  " + ex.Message);
                connection.SendObject(PacketTypes.CreateMeme.Response, ResponseMessage.ErrorOcured);
            }
        }

        public void GetMemesByUSerRequest(PacketHeader packetHeader, Connection connection, string incomingObject)
            
        {
            Console.WriteLine("o kuerwa ");
            //Guid key = Guid.NewGuid();
            //var userId = dummyAuthentication.LoggedUsers[key];

            //ConsoleMessage.ReqestReceived(packetHeader.PacketType);
            //var memes = memeRepository.Include(x => x.User).Where(x => x.User.Name == incomingObject);
            //connection.SendObject(PacketTypes.GetMemesByUser.Response, memes);
        }

        public void GetMemesByTitle(PacketHeader packetHeader, Connection connection, string incomingObject)
        {
            ConsoleMessage.ReqestReceived(packetHeader.PacketType);

            var memes = memeRepository.GetAllByCondition(x => x.Title == incomingObject);
            connection.SendObject(PacketTypes.GetMemesByTitle.Response, memes);
        }


        public static byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }

    }
}