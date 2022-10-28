using MovieRankingApplication.Model.Generated;

namespace MovieRankingApplication.ViewModels.Interfaces;

public interface IUserScoreViewModel
{
    public bool IsModified { get; }
    public UserScore Model { get; }
    long ScoreId { get; set; }
    long MovieId { get; set; }
    string UserName { get; set; }
    string ActingScore { get; set; }
    string CharacterScore { get; set; }
    string CinematographyScore { get; set; }
    string PlotScore { get; set; }
    string TotalScore { get; set; }
}
