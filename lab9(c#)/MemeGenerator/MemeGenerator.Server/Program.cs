using System;
using Autofac;
using MemeGeneratorServer;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Tools;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace MemeGenerator.Client.Server
{
    class Program
    {
        private static int port = 999;

        public static int Port
        {
            get { port++; return port; }
        }
        static void Main(string[] args)
        {
            //Start listening for incoming connections
            //  Connection.StartListening(ConnectionType.UDP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 12345));

            //Print out the IPs and ports we are now listening on
            //Console.WriteLine("Server listening for TCP connection on:");
            //foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.UDP))
            //{
            //  Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);
            //}

            //Node node1 = new Node("192.168.103.31", 10000);
            //Node node2 = new Node("192.168.103.35",10001);

            Node node1 = new Node("node 1", Port);
            var xad = HostInfo.AllLocalAdaptorNames();
            Node node2 = new Node("node 2", Port);
            
            Node node3 = new Node("node 3", Port);  
            Node node4 = new Node("node 4", Port);
            //foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.UDP))
            //{
            //    Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);
            //}
            while (true)
            {

                Console.WriteLine("\nPress any key to close server.");
               var x = Console.ReadLine();
                if (x != "")
                {
                    node1.SendBroadCast(Int32.Parse(x));
                }
            }

            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();
            
            //taking our server from container
            var server = container.Resolve<ServerApp>();

            //register all requests
            server.RegisterIncomingPackerHandlers();


            server.StartListeningUDP(11111);
            double a = 0;
            while (true)
            {
                a += 0.00001;
                //a = 0;
                if (a == 1000) 
                {
                    server.SendBroadCast(11111);
                }
            }
            
            //Let the user close the server
            Console.WriteLine("\nPress any key to close server.");
            Console.ReadKey(true);

            //We have used NetworkComms so we should ensure that we correctly call shutdown
            server.ShutDown();
        }
    }
}