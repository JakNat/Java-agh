using Autofac;
using MemeGenerator.Client.Server;
using MemeGenerator.Client.Server.Services;
using MemeGenerator.DataAccessLayer.Repositories;
using MemeGenerator.Model.Type;
using MemeGeneratorServer;
using System.Data.Entity;

namespace MemeGenerator.Tests
{
    public class Bootstraper
    {
        /// <summary>
        /// MemeGeneratpr server contener
        /// framework: autofac
        /// </summary>
        public class TestBase
        {
            protected IContainer container;
            public IContainer Bootstrap()
            {
                var builder = new ContainerBuilder();

                // database
                builder.RegisterInstance<DbContext>(new DummyDbContext());

                builder.RegisterInstance<DummyAuthentication>(new DummyAuthentication());

                // repositories
                builder.RegisterType<GenericRepository<Meme>>().As<IGenericRepository<Meme>>();
                builder.RegisterType<GenericRepository<User>>().As<IGenericRepository<User>>();

                // services
                builder.RegisterType<UserService>().As<IUserService>();
                builder.RegisterType<MemeService>().As<IMemeService>();

                builder.RegisterType<Encrypter>().As<IEncrypter>().SingleInstance();

                // server
                builder.RegisterType<ServerApp>().AsSelf();

                // client
                builder.RegisterType<ServerApp>().AsSelf();

                return builder.Build();
            }

            public TestBase()
            {
                container =  Bootstrap();
            }
        }
    }
}
