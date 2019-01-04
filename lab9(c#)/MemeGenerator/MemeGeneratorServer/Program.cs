using System;
using Autofac;
using MemeGenerator.Models;
using MemeGeneratorServer.Services;

namespace MemeGeneratorServer
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            Container = builder.Build();

            Server server = new Server();

            //Trigger the method SetMeme when a packet of type 'Meme' is received
            //We expect the incoming object to be a meme which we state explicitly by using <meme>
            server.AppendGlobalIncomingPacketHandler<ImageWrapper>("Meme", MemeService.SetMeme);
            server.AppendGlobalIncomingPacketHandler<LoginDto>("Login", UserService.Login);
            server.AppendGlobalIncomingPacketHandler<RegisterDto>("Register", UserService.Register);

            server.StartListening();
           
            //Let the user close the server
            Console.WriteLine("\nPress any key to close server.");
            Console.ReadKey(true);

            //We have used NetworkComms so we should ensure that we correctly call shutdown
            server.ShutDown();
        }

     

       
       
    }
}