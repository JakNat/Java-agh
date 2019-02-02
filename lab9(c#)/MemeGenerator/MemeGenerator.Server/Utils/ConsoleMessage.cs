using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Server.Utils
{
    public static class ConsoleMessage
    {
        public static void ReqestReceived(string packetType)
        {
            Console.WriteLine("\nServer received new reqest: '{0}'", packetType);
        }
    }
}
