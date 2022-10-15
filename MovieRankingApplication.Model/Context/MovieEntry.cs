namespace MovieRankingApplication.Model.Context;

public class MovieEntry
{
    public long MovieId { get; set; }
    public string MovieName { get; set; }
    public string MovieGenre { get; set; }
    public long MovieTotalScore { get; set; }
    public virtual ICollection<UserScore> UserScores { get; set; }
}
