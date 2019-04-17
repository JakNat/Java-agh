using Autofac;
using EntityFrameworkMock;
using MemeGenerator.Client;
using MemeGenerator.Client.Requests;
using MemeGenerator.Client.Server;
using MemeGenerator.Client.Server.Services;
using MemeGenerator.Client.ViewModels;
using MemeGenerator.DataAccessLayer;
using MemeGenerator.DataAccessLayer.Repositories;
using MemeGenerator.Model.Type;
using MemeGeneratorServer;
using System;
using System.Data.Entity;

namespace MemeGenerator.Tests
{
    public class TestBootstraper
    {
        protected IContainer container;
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            #region server

            // database
            var database = PrepareDataBase();
            builder.RegisterInstance<MemeGeneratorDBContext>(database);
            builder.RegisterInstance<DummyAuthentication>(new DummyAuthentication());

            // repositories
            builder.RegisterType<GenericRepository<Meme, MemeGeneratorDBContext>>().As<IGenericRepository<Meme>>();
            builder.RegisterType<GenericRepository<User, MemeGeneratorDBContext>>().As<IGenericRepository<User>>();

            // services
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MemeService>().As<IMemeService>();

            // server
            builder.RegisterType<ServerApp>().AsSelf().SingleInstance();

            #endregion

            #region cleint

            // viewModels
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<MemeLibraryViewModel>();

            builder.RegisterType<RegisterViewModel>();
            builder.RegisterType<Encrypter>().As<IEncrypter>().SingleInstance();

            // client
            builder.RegisterType<ClientApp>().As<IClientApp>().SingleInstance();
            builder.RegisterType<ClientRequests>().As<IClientRequests>();

            #endregion

            return builder.Build();
        }

        private MemeGeneratorDBContext PrepareDataBase()
        {
            var initialEntities = new[]
            {
                 new Meme { MemeId = 1, Title = "title 1",UserId = 1, CreatedDate = DateTime.Now},
                 new Meme { MemeId = 2, Title = "title 2",UserId = 1, CreatedDate = DateTime.Now},
                };

            var initialUsers = new[]
            {
                    new User {Name = "tester", UserId = 1, Password = "123qwe", CreatedDate = DateTime.Now }
                };

            var dbContextMock = new DbContextMock<MemeGeneratorDBContext>();

            var usersDbSetMock = dbContextMock.CreateDbSetMock(x => x.Users, initialUsers);
            var memesDbSetMock = dbContextMock.CreateDbSetMock(x => x.Memes, initialEntities);

            return dbContextMock.Object;
        }
    }

}
