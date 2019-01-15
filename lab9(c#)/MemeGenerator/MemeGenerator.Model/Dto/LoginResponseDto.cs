using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Model.Dto
{
    [ProtoContract]
    public class LoginResponseDto : BaseResponseDto
    {
        [ProtoMember(1)]
        public Guid? Key { get; set; }
    }
}
