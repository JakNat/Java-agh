using System;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections.TCP;

namespace MemeGenerator.Client
{
    public interface IClientApp
    {
        ConnectionInfo connectionInfo { get; set; }
        SendReceiveOptions customSendReceiveOptions { get; set; }
        Guid Key { get; set; }
        TCPConnection ServerConnection { get; set; }

        void GetConnection();
        void Shutdown();
    }
}