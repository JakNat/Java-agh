using Caliburn.Micro;
using MemeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }


        public void Login()
        {
            Client client = IoC.Get<Client>();
            client.GetConnection();
            var loginDto = new LoginDto()
            {
                Login = UserName,
                Password = Password
            };
            client.ServerConnection.SendObject("Login", loginDto);
        }
    }
}
