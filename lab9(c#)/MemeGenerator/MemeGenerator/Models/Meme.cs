using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkCommsDotNet;
using ProtoBuf;

namespace MemeGenerator.Models
{
    [ProtoContract]
    public class MemeDto
    {
        [ProtoMember(1)]
        public string TopText { get; set; }
        [ProtoMember(2)]
        public string BottomText { get; set; }
        [ProtoMember(3)]
        public byte[] ImgByte { get; internal set; }

        public MemeDto()
        {
        }

    }
}
