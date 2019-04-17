using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Connections.UDP;
using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.Net;

namespace MemeGeneratorServer
{
    public class Node
    {
        public int PortNumber { get; set; }
        public long IpAddress { get; set; } = HostInfo.IP.FilteredLocalAddresses()[0].Address;
        public UDPConnectionListener UDPConnectionListener { get; set; }

        private SendReceiveOptions optionsToUseForUDPInput;
        private UDPConnection _UDPConnection { get; set; }

        public Node(string nazwaNoda,int port)
        {
            PortNumber = port;
            ConnectionInfo connInfo = new ConnectionInfo(new IPEndPoint(IpAddress, PortNumber));
            _UDPConnection = UDPConnection.GetConnection(connInfo, UDPOptions.None);

            optionsToUseForUDPInput = NetworkComms.DefaultSendReceiveOptions;
            UDPConnectionListener = new UDPConnectionListener(NetworkComms.DefaultSendReceiveOptions, ApplicationLayerProtocolStatus.Enabled, UDPConnection.DefaultUDPOptions);
            AppendMethod(nazwaNoda);

            Connection.StartListening(UDPConnectionListener, new IPEndPoint(IpAddress, PortNumber));
        }

        private void AppendMethod(string nazwaNoda)
        {
            UDPConnectionListener.AppendIncomingPacketHandler<string>("ChatMessage",
                            (packetHeader, connection, incomingString) =>
                            {
                                Console.WriteLine($"\n  ..[{nazwaNoda}]. Incoming message from " +
                                    connection.ToString() + " saying '" +
                                    incomingString + "'.");
                            });
        }

        public void SendBroadCast(int port)
        {
            //List<IPEndPoint> endPointsToUse = new List<IPEndPoint>();
            //for (int i = 1000; i < 1010; i++)
            //{
            //    endPointsToUse.Add(new IPEndPoint(IPAddress.Broadcast, i));
            //}
            //foreach (var endPoint in endPointsToUse)
            //{
                _UDPConnection.SendObject("ChatMessage", "messagee");
            //}
        }
    }
}
