using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Model.Dto.Requests
{
    [ProtoContract]
    public class BaseRequest
    {
        [ProtoMember(1)]
        public Guid UserHash { get; set; }
    }
}
