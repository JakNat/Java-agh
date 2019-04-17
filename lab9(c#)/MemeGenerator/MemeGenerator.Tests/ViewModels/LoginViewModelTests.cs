using Autofac;
using MemeGenerator.Client.ViewModels;
using MemeGenerator.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MemeGenerator.Tests
{
    [Collection("Serial Tests")]
    public class LoginViewModelTests : TestBase
    {
        public LoginViewModelTests() : base()
        {
        }

        [Fact]
        public async void  Login_CorrectValues_ReturnLoginSuccessfullAndKey()
        {
            var loginViewModel = container.Resolve<LoginViewModel>();

            loginViewModel.UserName = "tester";
            loginViewModel.Password = "123qwe";

            var result =  loginViewModel.Login().Result;

            Assert.Equal(ResponseMessage.LoginSuccessfull, result.Message);
            Assert.NotNull(result.Key);

        }

        public async void Login_UserNameUpperCase_ReturnLoginSuccessfullAndKey()
        {
            var loginViewModel = container.Resolve<LoginViewModel>();

            loginViewModel.UserName = "TESTER";
            loginViewModel.Password = "123qwe";

            var result = loginViewModel.Login().Result;

            Assert.Equal(ResponseMessage.LoginSuccessfull, result.Message);
            Assert.NotNull(result.Key);

        }

        [Fact]
        public void Login_WrongPassword_ReturnLoginFailed()
        {
            var loginViewModel = container.Resolve<LoginViewModel>();

            loginViewModel.UserName = "tester";
            loginViewModel.Password = "123qwe3";

            var result =  loginViewModel.Login().Result;

            Assert.Equal(ResponseMessage.LogingFailed, result.Message);
            Assert.Null(result.Key);
        }

        [Fact]
        public void Login_WrongUserName_ReturnLoginFailed()
        {
            var loginViewModel = container.Resolve<LoginViewModel>();

            loginViewModel.UserName = "tester22";
            loginViewModel.Password = "123qwe";

            var result = loginViewModel.Login().Result;

            Assert.Equal(ResponseMessage.LogingFailed, result.Message);
            Assert.Null(result.Key);
        }

    }
}
