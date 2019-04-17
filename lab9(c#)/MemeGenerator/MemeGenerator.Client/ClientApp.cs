using MemeGenerator.Client.Requests;
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
    /// <summary>
    /// Client class
    /// </summary>
    public class ClientApp : IClientApp
    {
        //private readonly ClientRequests clientRequests;

        public ConnectionInfo connectionInfo { get; set; }
        public SendReceiveOptions customSendReceiveOptions { get; set; }
        public Guid Key { get; set; }

        public TCPConnection ServerConnection { get; set; }
        #region ctors
        public ClientApp()
        {
            this.customSendReceiveOptions = new SendReceiveOptions<ProtobufSerializer>();
        }
        #endregion

        public void GetConnection()
        {
            try
            {
                ServerConnection = TCPConnection.GetConnection(connectionInfo, customSendReceiveOptions);
              //  MessageBox.Show("You are connected to a server !");
            }
            catch (Exception)
            {
                //MessageBox.Show("Cannot get connection to a server");
            }
        }

        public void Shutdown()
        {
            ServerConnection = null;
        }


    }
}
