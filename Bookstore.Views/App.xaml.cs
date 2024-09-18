using Bookstore.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Bookstore.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXdfdnVTQmJcVER2Wko=");
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {            
            var appPath = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
            // For more information about .NET generic host see
            // https://docs.microsoft.com/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.0
            _host = Host.CreateDefaultBuilder(e.Args)
                    .ConfigureAppConfiguration(c =>
                    {
                        c.SetBasePath(appPath);
                    })
                    .ConfigureServices(ConfigureServices)
                    .Build();
            await _host.StartAsync();
            var startupView = _host.Services.GetRequiredService<MainWindow>();
            startupView.Show();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection collection)
        {
            collection.AddSingleton<ViewModelMain>();
            collection.AddSingleton<MainWindow>();

            collection.AddSingleton<ViewModelBook>();
            collection.AddSingleton<BookWindow>();
        }

        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host?.StopAsync();
            _host.Dispose();
            _host = null;
        }

        private IHost? _host;
    }
}
