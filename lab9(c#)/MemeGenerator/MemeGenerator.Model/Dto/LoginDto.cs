using ProtoBuf;

namespace MemeGenerator.Model.Dto
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
