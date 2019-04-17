using MemeGenerator.Model.Dto.Requests;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.UDP;
using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MemeGeneratorServer.Domain
{
    public class NodeListener<T> where T : BaseNode
    {
        public T Node { get; protected set; }
        public UDPConnectionListener UDPConnectionListener { get; protected set; }

        private List<Guid> ReceivedRequests = new List<Guid>();

        public NodeListener(T node)
        {
            Node = node;
            UDPConnectionListener= new UDPConnectionListener
                (NetworkComms.DefaultSendReceiveOptions, ApplicationLayerProtocolStatus.Enabled, UDPConnection.DefaultUDPOptions);
            RegisterRequest();
        }

        public void RegisterRequest()
        {
            UDPConnectionListener.AppendIncomingPacketHandler<Request>("Message", GetMemesByUSerRequest);
        }

        /// <summary>
        /// Ustawienie nasłuchiwania na wybranym porcie  dla danego noda
        /// </summary>
        public void StartListening()
        {
            var ip = HostInfo.IP.FilteredLocalAddresses()[0].Address;
            Connection.StartListening(UDPConnectionListener, new IPEndPoint(ip, Node.NodeId));
        }

        public void StopListening()
        {
            Connection.StopListening(UDPConnectionListener);
        }

        public void SendBroadCast(Request request)
        {
            Console.WriteLine("Node nr " + Node.NodeId + " sending away!");

            request.BroadCastingNodeId = Node.NodeId;
            //pobieramy wszystkie nody w zasięgu
            var nodesInRange = Node.GetAllNodesInRange();

            //wysylamy do nich wiadomość
            foreach (var nodeID in nodesInRange)
            {
                var endPoint = new IPEndPoint(IPAddress.Broadcast, nodeID);
                UDPConnection.SendObject("Message", request, endPoint);
            }
        }


        public void GetMemesByUSerRequest(PacketHeader packetHeader, Connection connection, Request incomingObject)
        {
            if (ReceivedRequests.Contains(incomingObject.RequestId))
            {
                Console.WriteLine("Node nr " + Node.NodeId + " blocked from nr " + incomingObject.BroadCastingNodeId);
                return;
            }
            else if (Node.SubsribedNodes.Contains(incomingObject.BroadCastingNodeId))
            {
                ReceivedRequests.Add(incomingObject.RequestId);
            }
            if (Node.SubsribedNodes.Contains(incomingObject.BroadCastingNodeId))
            {
                Console.WriteLine("Node nr " + Node.NodeId + " get message from {Node " + incomingObject.BroadCastingNodeId + "}");
                if (incomingObject.TargetNodeId == Node.NodeId)
                {
                    Console.WriteLine("CONGRATS!!");
                }else if(incomingObject.Heartbeats > 0)
                {
                    var newRequest = incomingObject;
                    newRequest.Heartbeats--;
                    newRequest.BroadCastingNodeId = Node.NodeId;
                    SendBroadCast(newRequest);
                }
                Console.WriteLine("something wrong");
            }
        }
    }
}
