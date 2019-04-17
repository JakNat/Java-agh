using Autofac;
using MemeGenerator.Model.Type;
using MemeGenerator.DataAccessLayer;
using MemeGenerator.DataAccessLayer.Repositories;
using MemeGenerator.Client.Server.Services;
using System.Data.Entity;
using MemeGeneratorServer;

namespace MemeGenerator.Client.Server
{
    /// <summary>
    /// MemeGeneratpr server contener
    /// framework: autofac
    /// </summary>
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            // database
            builder.RegisterType<MemeGeneratorDBContext>().AsSelf();

            builder.RegisterInstance<DummyAuthentication>(new DummyAuthentication());

            // repositories
            builder.RegisterType<GenericRepository<Meme, MemeGeneratorDBContext>>().As<IGenericRepository<Meme>>();
            builder.RegisterType<GenericRepository<User, MemeGeneratorDBContext>>().As<IGenericRepository<User>>();

            // services
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MemeService>().As<IMemeService>();

            builder.RegisterType<Encrypter>().As<IEncrypter>().SingleInstance();

            // server
            builder.RegisterType<ServerApp>().AsSelf().SingleInstance();

            return builder.Build();
        }
    }
}
