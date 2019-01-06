using MemeGenerator.Model.Dto;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;

namespace MemeGenerator.Client.Server.Services
{
    public interface IUserService
    {
        void LoginRequest(PacketHeader packetHeader, Connection connection, LoginDto incomingObject);
        void RegisterRequest(PacketHeader packetHeader, Connection connection, RegisterDto incomingObject);
    }
}
