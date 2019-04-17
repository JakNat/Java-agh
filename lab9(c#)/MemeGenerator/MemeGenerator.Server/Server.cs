using MemeGenerator.Model.Dto;
using MemeGenerator.Client.Server.Services;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using static NetworkCommsDotNet.NetworkComms;
using MemeGenerator.Model;
using System.Linq;
using NetworkCommsDotNet.Connections.UDP;
using System.Net;

namespace MemeGenerator.Client.Server
{
    /// <summary>
    /// Server class
    /// framework: NetworkComms 
    /// </summary>
    public class ServerApp
    {
        private readonly IMemeService memeService;
        private readonly IUserService userService;

        private int myVar = 1;
        private int broadCastPort = 12845;

        public int MyProperty
        {
            get { myVar++; return myVar ; }
        }


        public ServerApp(IMemeService memeService,
            IUserService userService
            )
        {
            this.memeService = memeService;
            this.userService = userService;
        }
        public string ServerAddress { get; set; }
        public void StartListening()
        {
            //Start listening for incoming connections
            Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 12345));

            //Print out the IPs and ports we are now listening on
            Console.WriteLine("Server listening for TCP connection on:");
            foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
            {
                if (ServerAddress == null)
                    ServerAddress = localEndPoint.Address.ToString();
                Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);
            }
        }
        public void StartListening(int port)
        {
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("ChatMessage",
    (packetHeader, connection, incomingString) =>
    {
        Console.WriteLine("\n  ... Incoming message from " +
            connection.ToString() + " saying '" +
            incomingString + "'.");
    });
            //Start listening for incoming connections
            Connection.StartListening(ConnectionType.UDP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, port));

            //Print out the IPs and ports we are now listening on
            Console.WriteLine("Server listening for TCP connection on:");
            foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
            {
                if (ServerAddress == null)
                    ServerAddress = localEndPoint.Address.ToString();
                Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);
            }
        }

        public void SendBroadCast(int port)
        {
            UDPConnection.SendObject("ChatMessage", "This is the broadcast test message!",
                new IPEndPoint(IPAddress.Broadcast, port));
        }
        public void StartListeningUDP(int port)
        {

            SendReceiveOptions optionsToUseForUDPInput = NetworkComms.DefaultSendReceiveOptions;
            var udpListener = new UDPConnectionListener(NetworkComms.DefaultSendReceiveOptions, ApplicationLayerProtocolStatus.Enabled, UDPConnection.DefaultUDPOptions);

            udpListener.AppendIncomingPacketHandler<string>("ChatMessage",
    (packetHeader, connection, incomingString) =>
    {
        Console.WriteLine($"\n  ..[{port}]. Incoming message from " +
            connection.ToString() + " saying '" +
            incomingString + "'.");
    });

            //udpListener.ConnectionType = ConnectionType.UDP;
            Connection.StartListening(udpListener, new IPEndPoint(System.Net.IPAddress.Any, port));
            Console.WriteLine("Server listening for UDP connection on:");
        //    SendBroadCast(port);
        }


        /// <summary>
        /// Register all client requests
        /// </summary>
        public void RegisterIncomingPackerHandlers()
        {
            //memeService requests
            NetworkComms.AppendGlobalIncomingPacketHandler<MemeDto>(PacketTypes.CreateMeme.Request, memeService.GenerateMemeRequest);
            NetworkComms.AppendGlobalIncomingPacketHandler<string>(PacketTypes.GetMemesByUser.Request, memeService.GetMemesByUSerRequest);
            NetworkComms.AppendGlobalIncomingPacketHandler<string>(PacketTypes.GetMemesByTitle.Request, memeService.GetMemesByTitle);

            //userService requests
            NetworkComms.AppendGlobalIncomingPacketHandler<LoginDto>(PacketTypes.Login.Request, userService.LoginRequest);
            NetworkComms.AppendGlobalIncomingPacketHandler<RegisterDto>(PacketTypes.Register.Request, userService.RegisterRequest);
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
