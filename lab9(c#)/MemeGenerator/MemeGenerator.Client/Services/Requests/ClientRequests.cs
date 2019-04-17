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
        private readonly IClientApp client;

        public ClientRequests(IClientApp client)
        {
            this.client = client;
        }


        private TCPConnection serverConnection
        {
            get { return client.ServerConnection; }
        }

        public LoginResponseDto LoginRequest(LoginDto loginDto)
        {
            return serverConnection?
              .SendReceiveObject<LoginDto, LoginResponseDto>
              (PacketTypes.Login.Request, PacketTypes.Login.Response, 10000, loginDto);
        }
    
        public BaseResponseDto CreateRequest(MemeDto memeDto)
        {
            return serverConnection?
              .SendReceiveObject<MemeDto, BaseResponseDto>
              (PacketTypes.CreateMeme.Request, PacketTypes.CreateMeme.Response, 20000, memeDto);
        }
       
        public List<MemeDto> LoadMemeByUser()
        {
            return serverConnection?
                .SendReceiveObject<string, List<MemeDto>>
                (PacketTypes.GetMemesByUser.Request, PacketTypes.GetMemesByUser.Response, 20000, client.Key.ToString());
        }
       
        public List<MemeDto> LoadMemeByTitle(string title)
        {
            return serverConnection?.
                SendReceiveObject<string, List<MemeDto>>
                (PacketTypes.GetMemesByTitle.Request, PacketTypes.GetMemesByTitle.Response, 20000, title);
        }

        public BaseResponseDto RegisterRequest(RegisterDto registerDto)
        {
            return serverConnection?
             .SendReceiveObject<RegisterDto, BaseResponseDto>
             (PacketTypes.Register.Request, PacketTypes.Register.Response, 50000, registerDto);
        }
    }
}
