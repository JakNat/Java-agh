using System;

namespace lab8
{
    partial class Program
    {
        static void Main(string[] args)
        {
            TcpServer server = new TcpServer();
            server.Run();

            while (true)
            {
                System.Threading.Thread.Sleep(500);
                Console.Write("\n Your request:");
                TcpClientHandler.ClientRequestString = Console.ReadLine();
                TcpClientHandler.ConnectAsTcpClient("127.0.0.1", 1234);
            }
        }
    }
}