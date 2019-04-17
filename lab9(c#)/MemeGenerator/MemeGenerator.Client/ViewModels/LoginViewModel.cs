using Caliburn.Micro;
using MemeGenerator.Client.Services;
using MemeGenerator.Model.Dto;
using System;
using System.Threading.Tasks;
using LoginDto = MemeGenerator.Model.Dto.LoginDto;

namespace MemeGenerator.Client.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IClientApp client;
        private readonly LoginService loginService;

        public LoginViewModel(IClientApp client, LoginService loginService)
        {
            this.client = client;
            this.loginService = loginService;
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
        public async Task<LoginResponseDto> Login()
        {
            // Call the server and attempt to login with credentials
            var result = await WebRequests.PostAsync<ApiResponse<UserProfileDetailsApiModel>>(
                // Set URL
                RouteHelpers.GetAbsoluteRoute(ApiRoutes.Login),
                // Create api model
                new LoginCredentialsApiModel
                {
                    UsernameOrEmail = Email,
                    Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                });

            // If the response has an error...
            if (await result.HandleErrorIfFailedAsync("Login Failed"))
                // We are done
                return;

            // OK successfully logged in... now get users data
            var loginResult = result.ServerResponse.Response;

            // Let the application view model handle what happens
            // with the successful login
            await ViewModelApplication.HandleSuccessfulLoginAsync(loginResult);


            var loginDto = new LoginDto()
            {
                Login = UserName,
                Password = Password
            };
            var response = await loginService.LoginButtonAction(loginDto);
            if (response.Key != null)
            {
                client.Key = (Guid)response.Key;
            }
            return response;
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
