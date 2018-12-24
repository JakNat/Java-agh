using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MemeGenerator.Models;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
 
namespace MemeGeneratorServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Trigger the method SetMeme when a packet of type 'Meme' is received
            //We expect the incoming object to be a meme which we state explicitly by using <meme>
            NetworkComms.AppendGlobalIncomingPacketHandler<Meme>("Meme", SetMeme);


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
      
        private static void SetMeme(PacketHeader header, Connection connection, Meme message)
        {
            Console.WriteLine("\nImage bytes: " + message.ImgByte);
        }
    }
}