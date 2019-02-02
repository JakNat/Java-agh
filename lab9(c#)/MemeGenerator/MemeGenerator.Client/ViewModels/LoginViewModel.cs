using Caliburn.Micro;
using MemeGenerator.Client.Requests;
using MemeGenerator.Model;
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
        private readonly IClientApp client;
        private readonly IClientRequests clientRequests;

        public LoginViewModel(IClientApp client, IClientRequests clientRequests)
        {
            this.client = client;
            this.clientRequests = clientRequests;
        }

        private string _userName;
        private string _password;

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

        #region Buttons

        /// <summary>
        /// button -> login to server
        /// </summary>
        public async void Login()
        {
            var loginDto = new LoginDto()
            {
                Login = UserName,
                Password = Password
            };

            try
            {
                LoginResponseDto response = await Task.Run(() => clientRequests.LoginRequest(loginDto));
                if(response.Key != null)
                {
                    client.Key = (Guid)response.Key;
                }
                MessageBox.Show("Server reponse: " + response.Message);
                MessageBox.Show("your key:" + response.Key);
            }
            catch (Exception)
            {
                MessageBox.Show("server not response");
            }
        }
        #endregion

        #region Validators

        /// <summary>
        /// validator -> Login button
        /// </summary>
        public bool CanLogin
        {
            get
            {
                return client?.ServerConnection != null
                && !String.IsNullOrWhiteSpace(UserName)
                && !String.IsNullOrWhiteSpace(Password);
            }
        }

        #endregion
    }
}
