using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Model.Dto.Requests
{
    [ProtoContract]
    public class LoginRequest : BaseRequest
    {
        [ProtoMember(1)]
        public string LoginName { get; set; }
    
        [ProtoMember(2)]
        public string Password { get; set; }
    }
}
