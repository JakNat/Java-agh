using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Model.Dto
{
    [ProtoContract]
    [ProtoInclude(500, typeof(LoginResponseDto))]
    public class BaseResponseDto
    {
        [ProtoMember(1)]
        public string Message { get; set; }
    }
}
