using Autofac;
using MemeGenerator.Client;
using MemeGenerator.Client.Server;
using NetworkCommsDotNet;
using System;

namespace MemeGenerator.Tests
{
    public class TestBase : IDisposable
    {
        protected string serverIp;
        protected IContainer container;

        public TestBase()
        {
            var bootstrapper = new Bootstrapper();
            container = bootstrapper.Bootstrap();
            PrepareServer();
            ConnectToServer();

            //   ConnectToServer();
        }
        public void Dispose()
        {
                 var server = container.Resolve<ServerApp>();
                   server.ShutDown();
        }
        private void PrepareServer()
        {
            //taking our server from container
            var server = container.Resolve<ServerApp>();

            //register all requests
            server.RegisterIncomingPackerHandlers();

            server.StartListening();
            serverIp = server.ServerAddress;
        }

        protected void ConnectToServer()
        {
            var client = container.Resolve<IClientApp>();
            //shut down old connection
            client.Shutdown();

            client.connectionInfo = new ConnectionInfo(serverIp, 12345);
            client.GetConnection();
        }
       
    }

}
