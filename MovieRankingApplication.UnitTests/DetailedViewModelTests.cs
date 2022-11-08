using MovieRankingApplication.ViewModels;
using MovieRankingApplication.ViewModels.PageViewModels;
using Moq;
using Microsoft.EntityFrameworkCore;
using MovieRankingApplication.Model.Generated;

using System;

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

    private Mock<MovieRankingDatabaseContext> GetMockDbWithBlankData()
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
        var mockContext = GetMockDbWithBlankData();

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
        var mockContext = GetMockDbWithBlankData();
        // add fake data
    }

}
