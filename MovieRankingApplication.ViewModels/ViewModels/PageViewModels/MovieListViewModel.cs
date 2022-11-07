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
    public List<IMovieEntryViewModel> MovieList { get; set; } = null!;


    public MovieListViewModel(IMovieRankingDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
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