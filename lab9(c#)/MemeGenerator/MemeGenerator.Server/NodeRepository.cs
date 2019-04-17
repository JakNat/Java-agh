using MemeGeneratorServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGeneratorServer
{
    public static class NodeRepository
    {
        public static List<BaseNode> Nodes { get; set; } = new List<BaseNode>();

        
        public static  void AddNode(BaseNode node)
        {
            Nodes.Add(node);
        }

        
        /// <summary>
        /// Do implementacji:
        /// powinno zwracać wszystkie node id które są w zasięgu
        /// </summary>
        public static IEnumerable<int> GetAllNodesInRange(this BaseNode node)
        {
            return Nodes.Select(x => x.NodeId);
        }

        
    }
}
