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
        public LoginViewModel(Client client)
        {
            this.client = client;
        }


        private string _userName;
        private string _password;
        private readonly Client client;

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

        //public bool CanLogin(Client client)
        //{
        //    return client?.ServerConnection != null;
        //}

        public void Login()
        {
            var loginDto = new LoginDto()
            {
                Login = UserName,
                Password = Password
            };
           // client.GetConnection();
            client.ServerConnection?.SendObject("Login", loginDto);
        }
    }
}
