using Autofac;
using MemeGenerator.Model.Type;
using MemeGenerator.DataAccessLayer;
using MemeGenerator.DataAccessLayer.Repositories;
using MemeGenerator.Client.Server.Services;
using System.Data.Entity;

namespace MemeGenerator.Client.Server
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            // database
            builder.RegisterInstance<DbContext>(new MemeGeneratorDBContext());

            // repositories
            builder.RegisterType<GenericRepository<Meme>>().As<IGenericRepository<Meme>>();
            builder.RegisterType<GenericRepository<User>>().As<IGenericRepository<User>>();

            // services
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MemeService>().As<IMemeService>();

            // server
            builder.RegisterType<ServerApp>().AsSelf();

            return builder.Build();
        }
    }
}
