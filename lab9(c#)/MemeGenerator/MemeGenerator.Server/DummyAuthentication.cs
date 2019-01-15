using MemeGenerator.Model.Dto;
using MemeGenerator.Model.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGeneratorServer
{
    public class DummyAuthentication
    {
        public Dictionary<Guid, int> LoggedUsers { get; }
        private Dictionary<Role, Guid> Access { get; set; } = new Dictionary<Role, Guid>();
        public Dictionary<Guid, Role> GlobalAcces { get; set; } = new Dictionary<Guid, Role>();
        public DummyAuthentication()
        {
            LoggedUsers = new Dictionary<Guid, int>();
            var rolesString = Enum.GetNames(typeof(Role)).ToList();
            var values = Enum.GetValues(typeof(Role));

            foreach (var value in values)
            {
                var hash = new Guid();
                var role = (Role)value;
                Access.Add(role, hash);
            //    GlobalAcces.Add(hash, role);
            }
        }

        public Guid AddUser(int userId)
        {
            Guid key = Guid.NewGuid();
            LoggedUsers.Add(key, userId);
            return key;
        }
    }

    public class DummyToken
    {
        public Guid UserHash { get; set; }
        public Guid RoleHash { get; set; }

        public DummyToken(LoginDto login)
        {
            GenerateKey(login.Login);
        }

        public void GenerateKey(string login)
        {
            UserHash = new Guid();
        }

        public string Modify(string str)
        {
            var newStr = "";
            foreach (var c in str)
            {
                newStr += (char)(c + 20);
            }
            return newStr;
        }
    }

    public enum Role
    {
        Administator = 1,
        Member = 2
    }
}
