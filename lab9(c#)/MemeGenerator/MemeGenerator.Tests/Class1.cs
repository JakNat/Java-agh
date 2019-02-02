using Autofac;
using MemeGenerator.Client.Server;
using MemeGenerator.Client.Server.Services;
using Xunit;

namespace MemeGenerator.Client.Tests
{
    public class TestSetup
    {

        protected IContainer container;
        public TestSetup()
        {
            var builder = new ContainerBuilder();

           
            

            // MemeGenerator database
          //  var db = new MemeGeneratorDBContext();

            // repositories
        
            // services
            //builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MemeService>().As<IMemeService>();

            // server
            builder.RegisterType<ServerApp>().AsSelf();

            container = builder.Build();

        }
    }
}
