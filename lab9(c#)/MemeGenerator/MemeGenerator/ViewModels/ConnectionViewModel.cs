using Caliburn.Micro;
using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.ViewModels
{
    public class ConnectionViewModel : Screen
    {
        private string _ipAdress = "172.16.80.1";

        public ConnectionViewModel(Client client)
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

        private int _port = 12345;
        private readonly Client client;

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
