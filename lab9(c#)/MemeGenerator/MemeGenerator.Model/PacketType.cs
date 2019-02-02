using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Model
{
    public static class PacketTypes
    {
        #region Meme service packets
        public static PacketType CreateMeme = new PacketType("CreateMeme");
        public static PacketType GetMemesByUser = new PacketType("GetMemesByUser");
        public static PacketType GetMemesByTitle = new PacketType("GetMemesByTitle");
        #endregion

        #region User service packets
        public static PacketType Login = new PacketType("Login");
        public static PacketType Register = new PacketType("Register");
        #endregion
    }

    public class PacketType
    {
        public PacketType(string packetType)
        {
            Request = packetType;
            Response = Request + "Response";
        }
        public string Request { get; }
        public string Response { get; }
    }

}
