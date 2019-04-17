using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Model.Responses
{
    public static class ResponseMessage
    {
        public static string LoginSuccessfull = "Login succed.";
        public static string LogingFailed = "Login failed.";

        public static string RegisterSuccessfull = "Register succed.";
        public static string RegisterFailed = "Register failed.";

        public static object MemeAdded = "New meme added.";

        public static object ErrorOcured = "Error ocured.";
        public static string NoConnection = "No connection to any server";
        public static string TimeOut = "To long server response.";
        public static string WrongPassword = "Wrong passwords.";
    }
}
