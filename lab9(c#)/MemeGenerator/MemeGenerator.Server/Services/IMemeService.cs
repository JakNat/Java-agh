using MemeGenerator.Model.Dto;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;

namespace MemeGenerator.Client.Server.Services
{
    public interface IMemeService
    {
        void GenerateMemeRequest(PacketHeader header, Connection connection, MemeDto message);
        void GetMemesByUSerRequest(PacketHeader packetHeader, Connection connection, string incomingObject);
        void GetMemesByTitle(PacketHeader packetHeader, Connection connection, string incomingObject);
    }
}