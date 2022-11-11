

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MovieRankingApplication.Model.Generated;
using MovieRankingApplication.ViewModels.DataObjectViewModels;
using MovieRankingApplication.ViewModels.Interfaces;
using MovieRankingApplication.MvvmHelpers;
using Microsoft.EntityFrameworkCore;

namespace MovieRankingApplication.ViewModels.PageViewModels;

public class DetailedViewModel
{
    private IMovieEntryViewModel _currentEntry;
    private IList<IUserScoreViewModel> _userScores;
    private IMovieRankingDatabaseContext _databaseContext;
    private IMainWindowViewModel _mainWinRef; // may be removed or updated
    //TESTING
    public bool HasFired = false;
    //Testing

    public DetailedViewModel(IMovieRankingDatabaseContext databaseContext, IMainWindowViewModel mainWinRef)
    {
        this._databaseContext = databaseContext;
        this._mainWinRef = mainWinRef;
        this._userScores = new List<IUserScoreViewModel>();
        CheckLoadTypeOrResetChanges();
    }

    #region Properties

    public IMovieEntryViewModel CurrentEntry
    {
        get => _currentEntry;
        set 
        {
            if(_currentEntry != value)
                _currentEntry = value;
        }
    }

    public IList<IUserScoreViewModel> UserScores
    {
        get => _userScores;
        set
        {
            if(_userScores != value)
                _userScores = value;
        }
    }

    public ICommand DoSaveChanges { get => new DelegateCommand(CheckTypeOfSave); }
    public ICommand DoResetChanges { get => new DelegateCommand(CheckLoadTypeOrResetChanges); }

    #endregion

    #region private helpers

    /// <summary>
    /// Checks if the program is in edit mode and executes the correct load method to ensure the correct starting state.
    /// Is also used to reset changes made and restore starting state.
    /// </summary>
    private void CheckLoadTypeOrResetChanges()
    {
        if ( _mainWinRef.EditMode == true)
            LoadEditMode();
        else LoadNewMode();
    }

    private void LoadNewMode()
    {
        _userScores.Clear();
        // Gets the highest value of entity instance Id from the database, if the database has no entries, value set to one.
        long HighestEntryId = _databaseContext.MovieEntries.Max(e => e == null ? 0 : e.MovieId);
        long HighestScoreId = _databaseContext.UserScores.Max(e => e == null ? 0 : e.ScoreId);

        _currentEntry = FreshMovieEntry(HighestEntryId);

       // Creates new userScores based off of the amount of usernames provided in mainWinRef 
        for (int i = 1; i <= _mainWinRef.UserNames.Count(); i++)
            _userScores.Add(FreshUserScore( i, HighestScoreId ));
    }
    private IMovieEntryViewModel FreshMovieEntry(long highestEntryId)
    {
        return new MovieEntryViewModel(new MovieEntry()
        {
            MovieId = highestEntryId + 1,
            MovieName = "UNSET",
            MovieGenre = "UNSET",
            MovieTotalScore = 0
        });
    }
    private IUserScoreViewModel FreshUserScore(int i, long highestScoreId)
    {
        return new UserScoreViewModel(new UserScore()
        {
            ScoreId = highestScoreId + (long)i,
            MovieId = _currentEntry.MovieId,
            UserName = _mainWinRef.UserNames[i - 1],
            ActingScore = 0L,
            CharacterScore = 0L,
            CinematographyScore = 0L,
            PlotScore = 0L,
            TotalScore = 0L
        });
    }



    private void LoadEditMode()
    {
        _currentEntry = _mainWinRef.SelectedModel;
        
        foreach(var score in _databaseContext.UserScores.Where(x => x.MovieId == _currentEntry.MovieId).ToList())
        {
            HasFired = true;
            _userScores.Add(new UserScoreViewModel(score)); // change to factory?
        }
    }

    /// <summary>
    /// Checks if the program is in edit mode and executes correct save method.
    /// </summary>
    private void CheckTypeOfSave()
    {
        if(_mainWinRef.EditMode == true)
            SaveChanges();
        else AddChanges();
    }

    /// <summary>
    /// Ensures only data that has been edited is sent to the database for updating.
    /// Exits the Detailed view after saving changes.
    /// </summary>
    private void SaveChanges()
    {
        if(_currentEntry.IsModified == true)
            _databaseContext.MovieEntries.Update(_currentEntry.Model);

        foreach( var Score in _userScores)
        {
            if(Score.IsModified == true)
                _databaseContext.UserScores.Update(Score.Model);
        }
        _databaseContext.DoSaveChanges();
        var temp = _mainWinRef.ChangetoListView; // requires testing, may not work.
    }

    /// <summary>
    /// Adds new data to the database.
    /// exits detailed view after completion.
    /// </summary>
    private void AddChanges()
    {
        _databaseContext.MovieEntries.Add(_currentEntry.Model);
        foreach (var Score in _userScores)
            _databaseContext.UserScores.Add(Score.Model);

        _databaseContext.DoSaveChanges();
        var temp = _mainWinRef.ChangetoListView; // requires testing, may not work.

    }
    #endregion
}