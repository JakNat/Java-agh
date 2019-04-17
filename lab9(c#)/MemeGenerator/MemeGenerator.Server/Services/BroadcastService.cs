using MemeGenerator.Model.Dto.Requests;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;

namespace MemeGeneratorServer.Services
{
    public class BroadcastService
    {

        public void GetMemesByUSerRequest(PacketHeader packetHeader, Connection connection, Request incomingObject)
        {
            Console.WriteLine("o kuerwa ");
        }
    }
}
