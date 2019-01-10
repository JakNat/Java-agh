using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Model
{
    public static class PacketType
    {
        private static string Return = "Return";

        #region Meme service packets

        public static string CreateMeme = "CreateMeme";
        public static string CreateMemeResponse = CreateMeme + Return;

        public static string GetMemesByUser = "GetMemesByUser";
        public static string GetMemesByUserResponse = GetMemesByUser + Return;

        public static string GetMemesByTitle = "GetMemesByTitle";
        public static string GetMemeByTitleResponse = GetMemesByTitle + Return;
        #endregion

        #region User service packets

        public static string Login = "Login";
        public static string LoginResponse = Login + Return;

        public static string Register = "Register";
        public static string RegisterResponse = Register + Return;
        #endregion
    }
}
