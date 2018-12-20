using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class TcpServer
    {
        public Dictionary<string, string> users { get; set; }
        public TcpListener tcpListener { get; set; }
        public List<string> LoggedIds { get; private set; }

        public TcpServer()
        {
            this.users = new Dictionary<string, string>()
            {
                { "user","p4ssw0rd" },
                {"user1","p4ssw0rd2" }
            };
            LoggedIds = new List<string>();
            StartListener(1234);
        }
        private  void StartListener(int code)
        {
            this.tcpListener = TcpListener.Create(code);
            tcpListener.Start();
        }

        public async void Run()
        {
            //waiting for client connection
            while (true)
            {
                var tcpClient = await tcpListener.AcceptTcpClientAsync();
                Console.WriteLine("[Server] Client has connected");
                await HandlingClientRequest(tcpClient);
            }
        }

        private async Task HandlingClientRequest(TcpClient tcpClient)
        {
            using (var networkStream = tcpClient.GetStream())
            {
                var buffer = new byte[4096];
                Console.WriteLine("[Server] Reading from client");
                var byteCount = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                var request = Encoding.UTF8.GetString(buffer, 0, byteCount);
                var splittedRequest = request.Split(' ');

                //protocols
                switch (splittedRequest[0].ToLower())
                {
                    case "login":
                        await LoginProtocol(networkStream, splittedRequest);
                        break;
                    case "logout":
                        await LogoutProtocol(networkStream, splittedRequest);
                        break;
                    default:
                        await NotFoundProtocol(networkStream, request);
                        break;
                }

                Console.WriteLine("[Server] Response has been written");
            }
        }

        #region Protocols

       
        /// <summary>
        /// Obsługa nie znalezionego protokołu
        /// </summary>
        /// <param name="networkStream"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private static async Task NotFoundProtocol(NetworkStream networkStream, string request)
        {
            await EncodeAndWriteServerResponse(networkStream, "Wrong request");
        }

        /// <summary>
        /// Obsługa protokołu logowania
        /// </summary>
        /// <param name="networkStream"></param>
        /// <param name="request">request klienta</param>
        /// <param name="splittedRequest">rozdzielony na słowa request klienta</param>
        /// <returns></returns>
        public  async Task LoginProtocol(NetworkStream networkStream, string[] splittedRequest)
        {
            var login = splittedRequest[1].ToLower();
            var password = splittedRequest[2];

            if (users.ContainsKey(login))
            {
                if (users[login] == password)
                {
                    string serwerResponseString = GenerateIdKey();
                    LoggedIds.Add(serwerResponseString);
                    Console.WriteLine("[Server] Login Protocol succesful");
                    await EncodeAndWriteServerResponse(networkStream, serwerResponseString);
                }
                else
                {
                    Console.WriteLine("[Server] Login Protocol failed : wrong password");
                    await EncodeAndWriteServerResponse(networkStream, "false");
                }
            }
            else
            {
                Console.WriteLine("[Server] Login Protocol failed : wrong login");
                await EncodeAndWriteServerResponse(networkStream, "false");
            }
        }

        /// <summary>
        /// Obsługa protokołu wylogowania
        /// </summary>
        /// <param name="networkStream"></param>
        /// <param name="request">request klienta</param>
        /// <param name="splittedRequest">rozdzielony na słowa request klienta</param>
        /// <returns></returns>
        public async Task LogoutProtocol(NetworkStream networkStream, string[] splittedRequest)
        {
            if (LoggedIds.Contains(splittedRequest[1]))
            {
                Console.WriteLine("[Server] Logout Protocol succesful");
                LoggedIds.Remove(splittedRequest[1]);
                await EncodeAndWriteServerResponse(networkStream, "true");
            }
            else
            {
                Console.WriteLine("[Server] Logout Protocol failed");
                await EncodeAndWriteServerResponse(networkStream, "false");
            }
        }
        #endregion

        /// <summary>
        /// Wysyłanie odpowiedzi serwera
        /// </summary>
        /// <param name="networkStream"></param>
        /// <param name="serwerResponseString">wiadomosc</param>
        /// <returns></returns>
        private static async Task EncodeAndWriteServerResponse(NetworkStream networkStream, string serwerResponseString)
        {
            var ServerResponseBytes = Encoding.UTF8.GetBytes(serwerResponseString);
            await networkStream.WriteAsync(ServerResponseBytes, 0, ServerResponseBytes.Length);
        }

        /// <summary>
        /// generowanie klucza logowania
        /// </summary>
        /// <returns>wygenerowany klucz</returns>
        private static string GenerateIdKey()
        {
            Random random = new Random();
            var serwerResponseString = "";
            for (int i = 0; i < 10; i++)
            {
                serwerResponseString += (char)random.Next(100);
            }
            return serwerResponseString;
        }
    }
}