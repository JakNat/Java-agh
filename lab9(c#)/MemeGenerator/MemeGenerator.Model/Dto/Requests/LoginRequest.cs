﻿using ProtoBuf;
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

    /// <summary>
    /// Wiadomość wysyłana między węzły
    /// ProtoContract służy do automatycznej serializacji i deserializacji obiektu do postaci bajtów 
    /// </summary>
    [ProtoContract]
    public class Request
    {
        [ProtoMember(1)]
        public Guid RequestId { get; set; }

        [ProtoMember(2)]
        public int TargetNodeId { get; set; }

        [ProtoMember(3)]
        public int BroadCastingNodeId { get; set; }

        [ProtoMember(4)]
        public string Message { get; set; }

        [ProtoMember(5)]
        public int Heartbeats { get; set; }
    }
}
