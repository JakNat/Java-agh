using Caliburn.Micro;
using MemeGenerator.Client.Requests;
using MemeGenerator.Model.Dto;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MemeGenerator.Client.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private readonly ClientApp client;
        private readonly IClientRequests clientRequests;

        public RegisterViewModel(ClientApp client, IClientRequests clientRequests)
        {
            this.client = client;
            this.clientRequests = clientRequests;
        }

        private string _userName;
        private string _password;
        private string _confirmPassword;

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

        #region Buttons
        /// <summary>
        /// Register button
        /// </summary>
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
                string response = await Task.Run(() => clientRequests.RegisterRequest(registerDto));
                MessageBox.Show("Server reponse: " + response);
            }
            catch (Exception)
            {
                MessageBox.Show("server not response");
            }
        }
        #endregion

        #region Validators
        /// <summary>
        /// Validator -> Register button
        /// </summary>
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
        #endregion
       
    }
}
