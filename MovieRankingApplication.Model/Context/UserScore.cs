namespace MovieRankingApplication.Model.Context;

public class UserScore
{
    public long ScoreId { get; set; }
    public long MovieId { get; set; }
    public string UserName { get; set; }
    public long CharacterScore { get; set; }
    public long CinematographyScore { get; set; }
    public long PlotScore { get; set; }
    public long TotalScore { get; set; }
    public virtual MovieEntry MovieEntry { get; set; }


}