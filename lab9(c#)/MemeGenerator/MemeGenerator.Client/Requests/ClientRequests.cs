using MemeGenerator.Model;
using MemeGenerator.Model.Dto;
using NetworkCommsDotNet.Connections.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Client.Requests
{
    /// <summary>
    /// Class for storing all client requests to server
    /// </summary>
    public class ClientRequests : IClientRequests
    {
        private readonly ClientApp client;

        public ClientRequests(ClientApp client)
        {
            this.client = client;
            serverConnection = client.ServerConnection;
        }

        private TCPConnection serverConnection;

        public LoginResponseDto LoginRequest(LoginDto loginDto)
        {
            return serverConnection?
              .SendReceiveObject<LoginDto, LoginResponseDto>
              (PacketType.Login, PacketType.LoginResponse, 10000, loginDto);
        }
    
        public string CreateRequest(MemeDto memeDto)
        {
            return serverConnection?
              .SendReceiveObject<MemeDto, string>
              (PacketType.CreateMeme, PacketType.CreateMemeResponse, 20000, memeDto);
        }
       
        public List<MemeDto> LoadMemeByUser()
        {
            return serverConnection?
                .SendReceiveObject<string, List<MemeDto>>
                (PacketType.GetMemesByUser, PacketType.GetMemesByUserResponse, 20000, "user");
        }
       
        public List<MemeDto> LoadMemeByTitle(string title)
        {
            return serverConnection?.
                SendReceiveObject<string, List<MemeDto>>
                (PacketType.GetMemesByTitle, PacketType.GetMemeByTitleResponse, 20000, title);
        }

        public string RegisterRequest(RegisterDto registerDto)
        {
            return serverConnection?
             .SendReceiveObject<RegisterDto, string>
             (PacketType.Register, PacketType.RegisterResponse, 10000, registerDto);
        }
     
    }
}
