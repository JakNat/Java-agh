using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Models
{
    [ProtoContract]
    public class LoginDto
    {
        [ProtoMember(1)]
        public string Login { get; set; }
        [ProtoMember(2)]
        public string Password { get; set; }
    }
}
