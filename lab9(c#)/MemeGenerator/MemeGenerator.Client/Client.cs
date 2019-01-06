using MemeGenerator.Model.Dto;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.DPSBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MemeGenerator.Client
{
    public class ClientApp
    {
        public ConnectionInfo connectionInfo { get; set; }
        public SendReceiveOptions customSendReceiveOptions { get; set; }

        public TCPConnection ServerConnection { get; set; }
        #region ctors
        public ClientApp()
        {
            this.customSendReceiveOptions = new SendReceiveOptions<ProtobufSerializer>();
            this.connectionInfo = new ConnectionInfo("172.16.80.1", 12345);
        }
        public ClientApp(ConnectionInfo connectionInfo)
        {
            this.customSendReceiveOptions = new SendReceiveOptions<ProtobufSerializer>();
            this.connectionInfo = connectionInfo;
        }

        public ClientApp(ConnectionInfo connectionInfo, SendReceiveOptions customSendReceiveOptions) : this(connectionInfo)
        {
            this.customSendReceiveOptions = customSendReceiveOptions;
        }
        #endregion

        public void GetConnection()
        {
            try
            {
                ServerConnection = TCPConnection.GetConnection(connectionInfo, customSendReceiveOptions);
                MessageBox.Show("You are connected to a server !");
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot get connection to a server");
            }
        }

        public void RegisterIncomingPackerHandlers()
        {
            //memeService requests
            //ServerConnection.AppendIncomingPacketHandler<MemeDto>("MemeResponse", memeService.GenerateMemeRequest);

            ////userService requests
            //ServerConnection.AppendIncomingPacketHandler<string>("LoginResponse", userService.LoginRequest);
            ServerConnection.AppendIncomingPacketHandler<string>("RegisterResponse", RegisterResonse);
        }

        private void RegisterResonse(PacketHeader packetHeader, Connection connection, string incomingObject)
        {
            MessageBox.Show(incomingObject);
        }

        public void Shutdown()
        {
            ServerConnection = null;
        }


    }
}
