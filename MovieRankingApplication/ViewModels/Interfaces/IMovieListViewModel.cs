
using System.Collections.Generic;
using MovieRankingApplication.Model.Context;

namespace MovieRankingApplication.ViewModels.Interfaces;

public interface IMovieListViewModel
{
    public List<MovieEntry> MovieList { get; }
}