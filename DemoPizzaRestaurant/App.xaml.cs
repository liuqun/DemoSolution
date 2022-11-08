using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoPizzaRestaurant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The `IServiceProvider` instance to resolve application services.
        /// </summary>
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            IServiceCollection services = CollectAllServices();

            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public static new App Current => (App)Application.Current;

        private static IServiceCollection CollectAllServices()
        {
            return new ServiceCollection()
                .AddSingleton<Demo.MainWindow>()
                .AddSingleton<Demo.MainWindowViewModel>();
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            Demo.MainWindow wnd = ServiceProvider.GetRequiredService<Demo.MainWindow>();
            wnd.Show();
            base.OnStartup(args);
        }
    }
}
