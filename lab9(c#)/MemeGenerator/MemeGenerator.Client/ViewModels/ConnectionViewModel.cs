using Caliburn.Micro;
using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Client.ViewModels
{
    public class ConnectionViewModel : Screen
    {
        private readonly ClientApp client;

        private string _ipAdress = "192.168.1.8";
        private int _port = 12345;
        public ConnectionViewModel(ClientApp client)
        {
            this.client = client;
        }
        public string IpAdress 
        {
            get { return _ipAdress; }
            set
            {
                _ipAdress = value;
                NotifyOfPropertyChange(() => IpAdress);
            }
        }

        public int Port
        {
            get { return _port; }
            set
            {
                _port = value;
                NotifyOfPropertyChange(() => Port);
            }
        }

        public void Connect()
        {
            client.Shutdown();
            client.connectionInfo = new ConnectionInfo(IpAdress, Port);
            client.GetConnection();
            if(client.ServerConnection != null)
            {

            }
        }

    }
}
