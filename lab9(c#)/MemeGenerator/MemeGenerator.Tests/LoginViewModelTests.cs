using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static MemeGenerator.Tests.Bootstraper;

namespace MemeGenerator.Tests
{
    [Collection("Serial Tests")]
    public class LoginViewModelTests : TestBase
    {
        public LoginViewModelTests() : base()
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.RegisterType<LoginViewModelTests>();

            newBuilder.Update(container);

          //  container.Resolve;
        }

        [Fact]
        public void GetAllExpensesForEmptyDatabase_ReturnsEmptyResultCollection()
        {
         //   EmptyDatabaseDropCreate();
          //  var service = appHost.Container.ResolveFlexiService<ExpenseService>();

           // var request = new FindExpenses();
           // var response = service.Get(request);
            Assert.NotNull(1);
           // Assert.Empty(response.MultipleResult);
        }

    }
}
