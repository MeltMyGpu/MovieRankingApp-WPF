using MovieRankingApplication.Model.Generated;

namespace MovieRankingApplication.ViewModels.Interfaces;

public interface IUserScoreViewModel
{
    public bool IsModified { get; }
    public UserScore Model { get; }
    long ScoreId { get; set; }
    long MovieId { get; set; }
    string UserName { get; set; }
    long ActingScore { get; set; }
    long CharacterScore { get; set; }
    long CinematographyScore { get; set; }
    long PlotScore { get; set; }
    long TotalScore { get; set; }
}
