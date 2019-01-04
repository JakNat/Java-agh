using ProtoBuf;

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
