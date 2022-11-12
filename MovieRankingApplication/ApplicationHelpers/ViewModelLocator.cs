using MovieRankingApplication.ViewModels.Interfaces;

namespace MovieRankingApplication.ApplicationHelpers;

public class ViewModelLocator
{
    // May need to  be static properties?
    public IMovieListViewModel? GetMoveListViewModel => (IMovieListViewModel?)App.AppHost!.Services.GetService(typeof(IMovieListViewModel));

    public IDetailedViewModel? GetDetailedViewModel => (IDetailedViewModel?)App.AppHost!.Services.GetService(typeof(IDetailedViewModel));

    public IMainWindowViewModel? GetMainWindowViewModel => (IMainWindowViewModel?)App.AppHost!.Services.GetService(typeof(IMainWindowViewModel));
}
