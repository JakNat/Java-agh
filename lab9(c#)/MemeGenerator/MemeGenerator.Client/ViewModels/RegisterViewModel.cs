using Caliburn.Micro;
using MemeGenerator.Client.Requests;
using MemeGenerator.Client.Services;
using MemeGenerator.Model.Dto;
using MemeGenerator.Model.Responses;
using NetworkCommsDotNet;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MemeGenerator.Client.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private readonly IClientApp client;
        private readonly RegisterService registerService;

        public RegisterViewModel(IClientApp client, RegisterService registerService )
        {
            this.client = client;
            this.registerService = registerService;
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
        public async Task<BaseResponseDto> Register()
        {
            var registerDto = new RegisterDto()
            {
                Login = UserName,
                Password = Password,
                ConfrimPassword = ConfirmPassword
            };

            return await registerService.RegisterButtonAction(registerDto);
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
