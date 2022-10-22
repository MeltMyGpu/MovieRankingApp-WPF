using System.Collections.Generic;
using MovieRankingApplication.Model.Context;
using MovieRankingApplication.MvvmHelpers;
using MovieRankingApplication.ViewModels.Interfaces;
using System;

namespace MovieRankingApplication.ViewModels;

public class MovieListViewModel : BindableBase ,IMovieListViewModel
{
    public List<MovieEntry> MovieList => throw new System.NotImplementedException();
    private IRankingDatabaseContext DatabaseContext;

    private void LoadMovieList()
    {
        throw new NotImplementedException();
    }
}