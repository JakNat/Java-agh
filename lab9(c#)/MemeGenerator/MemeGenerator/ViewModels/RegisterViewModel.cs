using Caliburn.Micro;
using MemeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private string _userName = "xd";
        private string _password = "lol";

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
        private string _confirmPassword;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                NotifyOfPropertyChange(() => ConfirmPassword);
            }
        }


        public void Register()
        {
            Client client = IoC.Get<Client>();
            client.GetConnection();
            var registerDto = new RegisterDto()
            {
                Login = UserName,
                Password = Password,
                ConfrimPassword = ConfirmPassword
            };
            client.ServerConnection.SendObject("Register", registerDto);
        }

    }
}
