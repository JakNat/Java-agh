using Caliburn.Micro;
using MemeGenerator.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MemeGenerator.Client.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private string _userName = "xd";
        private string _password = "lol";

        public RegisterViewModel(ClientApp client)
        {
            this.client = client;
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
           
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }
        
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }
        private string _confirmPassword;
        private readonly ClientApp client;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                NotifyOfPropertyChange(() => ConfirmPassword);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        public bool CanRegister
        {
            get
            {
                return
                client.ServerConnection != null
                && !String.IsNullOrWhiteSpace(UserName)
                && !String.IsNullOrWhiteSpace(Password);
            }
        }

        public async void Register()
        {
            var registerDto = new RegisterDto()
            {
                Login = UserName,
                Password = Password,
                ConfrimPassword = ConfirmPassword
            };
            try
            {
                string response = await Task.Run(() => RegisterRequest(registerDto));
                MessageBox.Show("Server reponse: " + response);
            }
            catch (Exception)
            {
                MessageBox.Show("server not response");
            }
        }

        private async Task<string> RegisterRequest(RegisterDto registerDto)
        {
            return client.ServerConnection?
              .SendReceiveObject<RegisterDto, string>
              ("Register", "RegisterResponse", 10000, registerDto);
        }
    }
}
