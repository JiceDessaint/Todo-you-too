namespace Specflow.specs
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using System.Diagnostics;
    using TodoYouToo;
    using TodoYouToo.Interfaces;
    using TodoYouToo.Data;
    using Specflow.specs.Helpers;

    public class AppBootstrapper : BootstrapperBase
    {
        SimpleContainer container;

        public AppBootstrapper(bool useApplication = false)
            : base(useApplication)
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.Singleton<IMain, MainViewModel>();
            container.PerRequest<IAddTodoPopup, AddTodoPopupViewModel>();
            container.Singleton<IDateTimeProvider, DateTimeProvider>();

            // Storage : We inject EntityFramework context and our repository
            container.PerRequest<IContext, Context>();
            container.PerRequest<ITodoRepository, TodoRepository>();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        //protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        //{
        //    DisplayRootViewFor<IMain>();
        //}
    }
}