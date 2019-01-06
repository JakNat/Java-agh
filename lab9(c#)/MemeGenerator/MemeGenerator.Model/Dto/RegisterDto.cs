using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Model.Dto
{
    [ProtoContract]
    public class RegisterDto
    {
        [ProtoMember(1)]
        public string Login { get; set; }
        [ProtoMember(2)]
        public string Password { get; set; }
        [ProtoMember(3)]
        public string ConfrimPassword { get; set; }
    }
}
