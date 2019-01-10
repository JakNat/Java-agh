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
        public Dictionary<DummyHash,User> LoggedUsers;

        public void AddUser(LoginDto login)
        {
            
        }
    }

    public class DummyHash
    {
        public string Key { get; set; }

        public DummyHash(LoginDto login)
        {
            GenerateKey(login.Login);
        }

        public void GenerateKey(string login)
        {
            Key = Modify(login) + DateTime.Now;
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
}
