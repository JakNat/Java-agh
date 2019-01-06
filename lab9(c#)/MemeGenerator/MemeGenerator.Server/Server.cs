using MemeGenerator.Model.Dto;
using MemeGenerator.Client.Server.Services;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using static NetworkCommsDotNet.NetworkComms;
using MemeGenerator.Model;

namespace MemeGenerator.Client.Server
{
    public class ServerApp
    {
        private readonly IMemeService memeService;
        private readonly IUserService userService;

        public ServerApp(IMemeService memeService,
            IUserService userService
            )
        {
            this.memeService = memeService;
            this.userService = userService;
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

        public void RegisterIncomingPackerHandlers()
        {
            //memeService requests
            NetworkComms.AppendGlobalIncomingPacketHandler<MemeDto>(PacketType.CreateMeme, memeService.GenerateMemeRequest);
            NetworkComms.AppendGlobalIncomingPacketHandler<string>(PacketType.GetMemesByUser, memeService.GetMemesByUSerRequest)

            //userService requests
            NetworkComms.AppendGlobalIncomingPacketHandler<LoginDto>(PacketType.Login, userService.LoginRequest);
            NetworkComms.AppendGlobalIncomingPacketHandler<RegisterDto>(PacketType.Register, userService.RegisterRequest);
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
