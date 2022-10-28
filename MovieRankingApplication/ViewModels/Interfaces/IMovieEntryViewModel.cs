using MovieRankingApplication.Model.Generated;

namespace MovieRankingApplication.ViewModels.Interfaces
{
    public interface IMovieEntryViewModel
    {
        public bool IsModified { get; }
        public MovieEntry Model { get; }

        string MovieGenre { get; set; }
        long MovieId { get; set; }
        string MovieName { get; set; }
        long MovieTotalScore { get; set; }
    }
}