using MovieRankingApplication.ViewModels;
using MovieRankingApplication.ViewModels.PageViewModels;
using Moq;
using Microsoft.EntityFrameworkCore;
using MovieRankingApplication.Model.Generated;

using System;
using MovieRankingApplication.ViewModels.DataObjectViewModels;

namespace MovieRankingApplication.UnitTests;

[TestClass]
public class DetailedViewModelTests
{
    private IQueryable<UserScore> UserData;
    private IQueryable<MovieEntry> MovieData;

    private static Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> Data) where T : class
    {
        // Generic method that provides a set-up mock DbSet of the provided type
        // Type is provided via the Queryable list parameter
        var mockset = new Mock<DbSet<T>>();
        mockset.As<IQueryable<T>>().Setup(m => m.Provider).Returns(Data.Provider);
        mockset.As<IQueryable<T>>().Setup(m => m.Expression).Returns(Data.Expression);
        mockset.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(Data.ElementType);
        mockset.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => Data.GetEnumerator());
        return mockset;
    }

    // DO NOT FORGET TO LOAD DATA BEFORE CALLING THIS.
    private Mock<MovieRankingDatabaseContext> GetMockDbContext()
    {
        // get mock sets and context
        var mockset = GetMockDbSet(UserData); // uses generic method to get an instance of Mock<DbSet<T>>
        var mockset2 = GetMockDbSet(MovieData);
        var mockContext = new Mock<MovieRankingDatabaseContext>();

        //sets the mock context.DbSets to return from the mockSet
        mockContext.Setup(m => m.UserScores).Returns(mockset.Object);
        mockContext.Setup(m => m.MovieEntries).Returns(mockset2.Object);
        return mockContext;
    }


    private void LoadTestData()
    {
        var UserDataToAdd = new List<UserScore>()
        {
            new UserScore { MovieId = 1, ScoreId = 1 },
            new UserScore { MovieId = 1, ScoreId = 2 },
            new UserScore { MovieId = 2, ScoreId = 3 },
            new UserScore { MovieId = 2, ScoreId = 4 },
            new UserScore { MovieId = 3, ScoreId = 5 },
            new UserScore { MovieId = 3, ScoreId = 6 }
        };
        foreach (var data in UserDataToAdd)
            UserData = UserData.Append(data);
        var MovieDataToAdd = new List<MovieEntry>()
        {
            new MovieEntry { MovieId = 1, MovieName = "Test1" },
            new MovieEntry { MovieId = 2, MovieName = "Test2" },
            new MovieEntry { MovieId = 3, MovieName = "Test3" }
        };
        MovieData = MovieData.Concat(MovieDataToAdd);
    }

    [TestInitialize]
    public void ResetMockData()
    {
        UserData = new List<UserScore>().AsQueryable();
        MovieData = new List<MovieEntry>().AsQueryable();
    }


    [TestMethod]
    public void StartingState_LoadNewMode_ShouldLoadNewObjects()
    {
        // Add blank data to mockData
        UserData = UserData.Append<UserScore>(new UserScore());
        MovieData = MovieData.Append<MovieEntry>(new MovieEntry());
        // Creates or fetches mock objects
        var mockMWViewM = new Mock<MainWindowViewModel>("Test1","Test2");
        var mockContext = GetMockDbContext();

        // sets the mock mainWinRef edit mode to return true
        mockMWViewM.SetupAllProperties();
        var trash = mockMWViewM.Object.ChangeToAddView;
        trash.Execute(new object());
        
        // creates test viewModel.
        var viewModel = new DetailedViewModel(mockContext.Object, mockMWViewM.Object);

        //tests
        Assert.AreEqual(viewModel.UserScores.Count, 2, "Amount of created objects incorrect");
        Assert.AreEqual(viewModel.CurrentEntry.MovieId, viewModel.UserScores[0].ScoreId, "Movie and first ScoreId Are not even");
        Assert.AreNotEqual(viewModel.CurrentEntry.MovieId, viewModel.UserScores[1].ScoreId, "Secong scoreId has not incremented");
    }

    [TestMethod]
    public void StartingState_LoadEditMode_ShouldLoadExistingObjects()
    {
        // fetch mock objects
        var mockMainWinRef = new Mock<MainWindowViewModel>("Test1","Test2");
        mockMainWinRef.SetupAllProperties();
        mockMainWinRef.Object.SelectedModel = new MovieEntryViewModel( new MovieEntry { MovieId = 2, MovieName = "Test2" });
        // add fake data
        LoadTestData();
        // Get mock Context using loaded with fake data
        var mockContext = GetMockDbContext();


        var viewModel = new DetailedViewModel(mockContext.Object, mockMainWinRef.Object);
        // Data extraction for Assets
        var UserScoreIndex0 = viewModel.UserScores[0];
        var UserScoreIndex1 = viewModel.UserScores[1];

        //Tests
        Assert.AreEqual(viewModel.CurrentEntry.MovieId, 2, "MovieIDWrong");
        Assert.IsTrue(viewModel.HasFired, "notloadingproperly");
        Assert.AreEqual(UserScoreIndex0.MovieId, 2L, "user score Movie Id Incorrect");
        Assert.AreNotEqual(UserScoreIndex0.ScoreId, UserScoreIndex1.ScoreId, "Same data loaded into both Indexs");
    }

}
