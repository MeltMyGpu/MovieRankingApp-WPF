
using System.Collections.Generic;


namespace MovieRankingApplication.ViewModels.Interfaces;

public interface IMovieListViewModel
{
    public List<IMovieEntryViewModel> MovieList { get; set; }
}