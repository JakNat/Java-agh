using Caliburn.Micro;
using MemeGenerator.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LoginDto = MemeGenerator.Model.Dto.LoginDto;

namespace MemeGenerator.Client.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly ClientApp client;

        private string _userName;
        private string _password;
        public LoginViewModel(ClientApp client)
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
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public bool CanLogin
        {
            get
            {
                return client?.ServerConnection != null
                && !String.IsNullOrWhiteSpace(UserName)
                && !String.IsNullOrWhiteSpace(Password);
            }
        }

        public async void Login()
        {
            var loginDto = new LoginDto()
            {
                Login = UserName,
                Password = Password
            };

            try
            {
                string response = await Task.Run(() => LoginRequest(loginDto));
                MessageBox.Show("Server reponse: " + response);
            }
            catch (Exception)
            {
                MessageBox.Show("server not response");
            }
        }

        private async Task<string> LoginRequest(LoginDto loginDto)
        {
            return client.ServerConnection?
              .SendReceiveObject<LoginDto, string>
              ("Login", "LoginResponse", 10000, loginDto);
        }
    }
}
