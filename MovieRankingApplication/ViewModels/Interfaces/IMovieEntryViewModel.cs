namespace MovieRankingApplication.ViewModels.Interfaces
{
    public interface IMovieEntryViewModel
    {
        string MovieGenre { get; set; }
        long MovieId { get; set; }
        string MovieName { get; set; }
        long MovieTotalScore { get; set; }
    }
}