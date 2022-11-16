using System.Collections.Generic;
using MovieRankingApplication.MvvmHelpers;
using MovieRankingApplication.ViewModels.Interfaces;
using MovieRankingApplication.ViewModels.DataObjectViewModels;
using System.Linq;
using MovieRankingApplication.Model.Generated;

namespace MovieRankingApplication.ViewModels.PageViewModels;

public class MovieListViewModel : BindableBase, IMovieListViewModel
{
    private readonly IMovieRankingDatabaseContext _databaseContext;
    public List<IMovieEntryViewModel> MovieList { get; set; }
    public IMainWindowViewModel MainWinRef { get; }


    public MovieListViewModel(IMovieRankingDatabaseContext databaseContext, IMainWindowViewModel mainWinRef)
    {
        _databaseContext = databaseContext;
        MainWinRef = mainWinRef;
        MovieList = new();
        LoadMovieList();
    }

    private void LoadMovieList()
    {
        foreach(var entry in _databaseContext.MovieEntries.ToList() )
        {
            MovieList.Add(new MovieEntryViewModel(entry));
        }
    }

}