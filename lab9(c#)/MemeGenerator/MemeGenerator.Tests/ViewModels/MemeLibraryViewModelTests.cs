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

    public class MemeLibraryViewModelTests : TestBase
    {
        public MemeLibraryViewModelTests(): base()
        {
            var loginViewModel = container.Resolve<LoginViewModel>();

            loginViewModel.UserName = "tester";
            loginViewModel.Password = "123qwe";
            loginViewModel.Login();
        }

        [Fact]
        public void GetMemes()
        {
            var registerViewModel = container.Resolve<MemeLibraryViewModel>();


            var result = registerViewModel.LoadMemeByUser();

           // Assert.NotEmpty(result);
        }
    }
}
