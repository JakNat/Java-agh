using Caliburn.Micro;
using MemeGenerator.Client.Requests;
using MemeGenerator.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MemeGenerator.Client
{
    public class AppBootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();

            container.RegisterInstance(typeof(ClientApp), null, new ClientApp());
            container.PerRequest<IClientRequests,ClientRequests>();

            #region view models
            container.PerRequest<ShellViewModel>();
            container.PerRequest<LoginViewModel>();
            container.PerRequest<ConnectionViewModel>();
            container.PerRequest<RegisterViewModel>();
            container.PerRequest<MemeLibraryViewModel>();
            container.PerRequest<MemeCreatorViewModel>();
            #endregion

        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

    }
}
