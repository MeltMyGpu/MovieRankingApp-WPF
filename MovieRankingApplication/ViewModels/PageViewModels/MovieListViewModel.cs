using System.Collections.Generic;
using MovieRankingApplication.Model.Context;
using MovieRankingApplication.MvvmHelpers;
using MovieRankingApplication.ViewModels.Interfaces;
using System;
using MovieRankingApplication.ViewModels.DataObjectViewModels;
using System.Linq;

namespace MovieRankingApplication.ViewModels.PageViewModels;

public class MovieListViewModel : BindableBase, IMovieListViewModel
{
    private readonly IRankingDatabaseContext _databaseContext;
    public List<IMovieEntryViewModel> MovieList { get; set; } = null!;


    public MovieListViewModel(IRankingDatabaseContext databaseContext)
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