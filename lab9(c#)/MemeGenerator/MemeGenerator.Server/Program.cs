using System;
using System.Collections.Generic;
using Autofac;
using MemeGenerator.Model.Dto.Requests;
using MemeGeneratorServer;
using MemeGeneratorServer.Domain;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Tools;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace MemeGenerator.Client.Server
{
    class Program
    {
        private static int port = 999;

        public static int Port
        {
            get { port++; return port; }
        }
        static void Main(string[] args)
        {
            List<BaseNode> nodes = new List<BaseNode>()
            {
                new BaseNode(1),
                new BaseNode(2),
                new BaseNode(3),
                new BaseNode(4),
                new BaseNode(5),
                new BaseNode(6),
            };

            foreach (var node in nodes)
            {
                NodeRepository.AddNode(node);
            }

            List<NodeListener<BaseNode>> listeners = new List<NodeListener<BaseNode>>();
            foreach (var node in nodes)
            {
                var listener = new NodeListener<BaseNode>(node);
                listener.StartListening();
                listeners.Add(listener);
            }

            //subskrybowanie
            nodes[0].SubsribedNodes = new List<int>() { 2, 4 };
            nodes[1].SubsribedNodes = new List<int>() { 1, 3 };
            nodes[2].SubsribedNodes = new List<int>() { 2, };
            nodes[3].SubsribedNodes = new List<int>() { 1 };
            nodes[4].SubsribedNodes = new List<int>() { 6 };
            nodes[5].SubsribedNodes = new List<int>() { 3 };

            NodeRepository.Nodes = nodes;
            var request = new Request()
            {
                Heartbeats = 3,
                Message = "nice",
                TargetNodeId = 5,
                RequestId = Guid.NewGuid()
            };

            listeners[0].SendBroadCast(request);
         
            //Let the user close the server
            Console.WriteLine("\nPress any key to close server.");
            Console.ReadKey(true);

            //We have used NetworkComms so we should ensure that we correctly call shutdown
           
        }
    }
}