using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using static NetworkCommsDotNet.NetworkComms;

namespace MemeGeneratorServer
{
    public class Server
    {

        public Server()
        {
            
        }

        public void StartListening()
        {
            //Start listening for incoming connections
            Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 12345));

            //Print out the IPs and ports we are now listening on
            Console.WriteLine("Server listening for TCP connection on:");
            foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
                Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);
        }

        /// <summary>
        /// We have used NetworkComms so we should ensure that we correctly call shutdown
        /// </summary>
        public void ShutDown()
        {
            Shutdown();
        }

        /// <summary>
        ///  Trigger the method packetHandlerDelgatePointer when a packet of type 'packetTypeStr' is received
        ///  We expect the incoming object to be a incomingObjectType which we state explicitly by using <incomingObjectType>
        /// </summary>
        public void AppendGlobalIncomingPacketHandler<incomingObjectType>(string packetTypeStr, PacketHandlerCallBackDelegate<incomingObjectType> packetHandlerDelgatePointer)
        {
            NetworkComms.AppendGlobalIncomingPacketHandler<incomingObjectType>(packetTypeStr, packetHandlerDelgatePointer);
        }
    }
}
