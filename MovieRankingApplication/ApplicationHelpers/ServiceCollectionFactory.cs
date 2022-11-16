
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieRankingApplication.Model.Generated;
using MovieRankingApplication.ViewModels.DataObjectViewModels;
using MovieRankingApplication.ViewModels.Interfaces;
using MovieRankingApplication.ViewModels.PageViewModels;

namespace MovieRankingApplication.ApplicationHelpers;

public static class ServiceCollectionFactory
{
    /// <summary>
    /// Sets up the ServiceHost with all required services 
    /// </summary>
    /// <returns>IHost with compelete service collection</returns>
    public static IHost SetupHost()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
                services.AddDbContext<IMovieRankingDatabaseContext, MovieRankingDatabaseContext>();
                services.AddTransient<IMovieListViewModel, MovieListViewModel>();
                services.AddTransient<IDetailedViewModel, DetailedViewModel>();
                services.AddSingleton<ViewModelLocator>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
    }
}
