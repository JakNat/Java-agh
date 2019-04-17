using Autofac;
using MemeGenerator.Client.ViewModels;
using MemeGenerator.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MemeGenerator.Tests.ViewModels
{
    [Collection("Serial Tests")]

    public class RegisterViewModelTests : TestBase
    {
        [Fact]
        public void Register_ValidProperties_ReturnRegisterSuccessfull()
        {
            var registerViewModel = container.Resolve<RegisterViewModel>();
            registerViewModel.UserName = "newUser";
            registerViewModel.Password = "123qwe";
            registerViewModel.ConfirmPassword = "123qwe";

            var result = registerViewModel.Register().Result;

            Assert.Equal(ResponseMessage.RegisterSuccessfull, result.Message);
        }
        [Fact]
        public void Register_InvalidPassword_ReturnInvalidPassword()
        {
            var registerViewModel = container.Resolve<RegisterViewModel>();
            registerViewModel.UserName = "newUser";
            registerViewModel.Password = "123dqwe";
            registerViewModel.ConfirmPassword = "123qwe";

            var result = registerViewModel.Register().Result;

            Assert.Equal(ResponseMessage.WrongPassword, result.Message);
        }
        [Fact]
        public void Register_InvalidUserName_ReturnInvalidUserName()
        {
            var registerViewModel = container.Resolve<RegisterViewModel>();
            registerViewModel.UserName = "tester";
            registerViewModel.Password = "123qwe";
            registerViewModel.ConfirmPassword = "123qwe";

            var result = registerViewModel.Register().Result;

            Assert.Equal(ResponseMessage.RegisterFailed, result.Message);
        }

    }
}
