using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieRankingApplication.ApplicationHelpers;
using System.Windows;

namespace MovieRankingApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = ServiceCollectionFactory.SetupHost();

            // Declaring ResourceDictonary here, must also be done in .xaml
            Resources = new ResourceDictionary(); 
            Resources.Add("ViewModelLocator", AppHost.Services.GetRequiredService<ViewModelLocator>());
        }

        protected override async void OnStartup(StartupEventArgs startupArgs)
        {
            base.OnStartup(startupArgs);
            // Done here to ensure that the AppHost has started before a page load makes a request to it//
            await AppHost!.StartAsync();
            // safe to start app
            var StartUpPage = AppHost.Services.GetRequiredService<MainWindow>();
            StartUpPage.Show();
        }

        protected override async void OnExit(ExitEventArgs exitArgs)
        {
            // ensures Apphost has stopped before closing down the application.
            await AppHost!.StopAsync();
            base.OnExit(exitArgs);
        }
    }
}
