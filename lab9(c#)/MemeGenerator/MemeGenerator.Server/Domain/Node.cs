using System.Collections.Generic;
using System.Drawing;

namespace MemeGeneratorServer.Domain
{
    public class BaseNode
    {
        /// <summary>
        /// traktujemy node id jako jego numer portu
        /// zakres 0 - 65535
        /// </summary>
        public int NodeId { get; protected set; }

        public List<int> SubsribedNodes { get; set; } = new List<int>();

        public Point Posistion { get; set; }

        public BaseNode(int nodeId)
        {
            
            SetNodeId(nodeId);
        }

        public void SetNodeId(int nodeId)
        {
            if (NodeId < 0 || NodeId > 65535)
            {
                throw new System.ArgumentException("NodeId must be between 0-65535");
            }
            NodeId = nodeId;
        }
    }
}
