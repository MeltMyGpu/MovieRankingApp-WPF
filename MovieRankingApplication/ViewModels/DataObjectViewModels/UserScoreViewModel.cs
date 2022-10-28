
using MovieRankingApplication.Model.Generated;
using MovieRankingApplication.MvvmHelpers;
using MovieRankingApplication.ViewModels.Interfaces;

namespace MovieRankingApplication.ViewModels.DataObjectViewModels;

public class UserScoreViewModel : BindableBase, IUserScoreViewModel
{
    private UserScore _userScore;
    private bool _isModified = false;
    public UserScoreViewModel(UserScore? userScore = null) => this._userScore = userScore ?? new UserScore();


    public bool IsModified { get => _isModified; }
    public UserScore Model { get => _userScore; }
    public long ScoreId
    {
        get => _userScore.ScoreId;
        set
        {
            if (_userScore.ScoreId != value)
            {
                _userScore.ScoreId = value;
                OnPropertyChanged();
                _isModified = true;
            }
        }
    }

    public long MovieId
    {
        get => _userScore.MovieId;
        set
        {
            if (_userScore.MovieId != value)
            {
                _userScore.MovieId = value;
                OnPropertyChanged();
                _isModified = true;
            }
        }
    }

    public string UserName
    {
        get => _userScore.UserName;
        set
        {
            if (_userScore.UserName != value)
            {
                _userScore.UserName = value;
                OnPropertyChanged();
                _isModified = true;
            }
        }
    }

    public string ActingScore
    {
        get => _userScore.ActingScore;
        set
        {
            if (_userScore.ActingScore != value)
            {
                _userScore.ActingScore = value;
                OnPropertyChanged();
                _isModified = true;
            }
        }
    }

    public string CharacterScore
    {
        get => _userScore.CharacterScore;
        set
        {
            if (_userScore.CharacterScore != value)
            {
                _userScore.CharacterScore = value;
                OnPropertyChanged();
                _isModified = true;
            }
        }
    }

    public string CinematographyScore
    {
        get => _userScore.CinematographyScore;
        set
        {
            if (_userScore.CinematographyScore != value)
            {
                _userScore.CinematographyScore = value;
                OnPropertyChanged();
                _isModified = true;
            }
        }
    }

    public string PlotScore
    {
        get => _userScore.PlotScore;
        set
        {
            if (_userScore.PlotScore != value)
            {
                _userScore.PlotScore = value;
                OnPropertyChanged();
                _isModified = true;
            }
        }
    }

    public string TotalScore
    {
        get => _userScore.TotalScore;
        set
        {
            if (_userScore.TotalScore != value)
            {
                _userScore.TotalScore = value;
                OnPropertyChanged();
                _isModified = true;
            }
        }
    }
}