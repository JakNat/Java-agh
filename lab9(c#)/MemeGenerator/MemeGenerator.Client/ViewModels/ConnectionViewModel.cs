using Caliburn.Micro;
using NetworkCommsDotNet;

namespace MemeGenerator.Client.ViewModels
{
    public class ConnectionViewModel : Screen
    {
        private readonly IClientApp client;

        public ConnectionViewModel(IClientApp client)
        {
            this.client = client;
        }

        private string _ipAdress = "192.168.1.8";
        private int _port = 12345;

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

        #region Buttons
        /// <summary>
        /// button -> Get server connection
        /// </summary>
        public void Connect()
        {
            //shut down old connection
            client.Shutdown();

            client.connectionInfo = new ConnectionInfo(IpAdress, Port);
            client.GetConnection();
            if(client.ServerConnection != null)
            {

            }
        }
        #endregion
    }
}
