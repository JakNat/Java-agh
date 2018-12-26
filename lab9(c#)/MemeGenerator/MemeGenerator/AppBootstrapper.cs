using Caliburn.Micro;
using MemeGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MemeGenerator
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

            // register MemeCreatorViewModel as singleton
            container.RegisterInstance(typeof(MemeCreatorViewModel),null,new MemeCreatorViewModel());

            //  container.RegisterInstance(typeof(Client), new Client());
            container.RegisterInstance(typeof(Client), null, new Client());

            container.PerRequest<ShellViewModel>();

      
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
