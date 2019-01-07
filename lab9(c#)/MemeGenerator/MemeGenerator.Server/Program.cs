using System;
using System.Linq;
using Autofac;
using MemeGenerator.Client.Server.Services;
using MemeGenerator.DataAccessLayer;

namespace MemeGenerator.Client.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //build our container
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();
            
            //taking our server from container
            var server = container.Resolve<ServerApp>();

            //register all requests
            server.RegisterIncomingPackerHandlers();

            server.StartListening();
           
            //Let the user close the server
            Console.WriteLine("\nPress any key to close server.");
            Console.ReadKey(true);

            //We have used NetworkComms so we should ensure that we correctly call shutdown
            server.ShutDown();
        }   
    }
}