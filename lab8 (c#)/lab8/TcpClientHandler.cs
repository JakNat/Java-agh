using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    partial class Program
    {
        static class TcpClientHandler
        {
            public static string ClientRequestString = "";
            private static readonly byte[] ClientRequestBytes = Encoding.UTF8.GetBytes(ClientRequestString);

            public static async void ConnectAsTcpClient(string host, int port)
            {
                using (var tcpClient = new TcpClient())
                {
                    Console.WriteLine("[Client] Connecting to server");
                    await tcpClient.ConnectAsync(host, port);
                    Console.WriteLine("[Client] Connected to server");
                    using (var networkStream = tcpClient.GetStream())
                    {
                        string message = ClientRequestString;
                        Console.WriteLine("[Client] Writing request '{0}'", message);

                        byte[] encodedRequest = Encoding.UTF8.GetBytes(message);
                        await networkStream.WriteAsync(encodedRequest, 0, encodedRequest.Length);

                        string response = await EncodeResponse(networkStream);
                        Console.WriteLine("[Client] Server response '{0}'", response);
                    }
                }
            }

            private static async Task<string> EncodeResponse(NetworkStream networkStream)
            {
                var buffer = new byte[4096];
                var byteCount = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                var response = Encoding.UTF8.GetString(buffer, 0, byteCount);
                return response;
            }
        }
    }
}