using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.DPSBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MemeGenerator
{
    public class Client
    {
        public ConnectionInfo connectionInfo { get; set; }
        public SendReceiveOptions customSendReceiveOptions { get; set; }

        public TCPConnection ServerConnection { get; set; }

        public Client()
        {
            this.customSendReceiveOptions = new SendReceiveOptions<ProtobufSerializer>();
            this.connectionInfo = new ConnectionInfo("192.168.103.36", 12345);
        }
        public Client(ConnectionInfo connectionInfo)
        {
            this.customSendReceiveOptions = new SendReceiveOptions<ProtobufSerializer>();
            this.connectionInfo = connectionInfo;
        }

        public Client(ConnectionInfo connectionInfo, SendReceiveOptions customSendReceiveOptions) : this(connectionInfo)
        {
            this.customSendReceiveOptions = customSendReceiveOptions;
        }
        public void GetConnection()
        {
            try
            {
                ServerConnection = TCPConnection.GetConnection(connectionInfo, customSendReceiveOptions);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot get connection to a server");
            }
        }

        public void Shutdown()
        {
            NetworkComms.Shutdown();
        }


    }
}
