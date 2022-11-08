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
    public static Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> Data) where T : class
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

    [TestMethod]
    public void Load_In_NewMode()
    {
        // fake data for mock sets
        var userData = new List<UserScore>{ new UserScore() }.AsQueryable();
        var movieData = new List<MovieEntry>{ new MovieEntry() }.AsQueryable();

        // Creates and setup Mock Objects
        var mockMWViewM = new Mock<MainWindowViewModel>("Test1","Test2");
        var mockset = GetMockDbSet(userData); // uses generic method to get an instance of Mock<DbSet<T>>
        var mockset2 = GetMockDbSet(movieData);
        var mockContext = new Mock<MovieRankingDatabaseContext>();

        //sets the mock context.DbSets to return from the mockSet
        mockContext.Setup(m => m.UserScores).Returns(mockset.Object); 
        mockContext.Setup(m => m.MovieEntries).Returns(mockset2.Object);


        // sets the mock mainWinRef edit mode to return true
        mockMWViewM.SetupAllProperties();
        var trask = mockMWViewM.Object.ChangeToAddView;
        trask.Execute(new object());
        
        // creates test viewModel.
        var viewModel = new DetailedViewModel(mockContext.Object, mockMWViewM.Object);

        //tests
        Assert.AreEqual(viewModel.UserScores.Count, 2);
        Assert.AreEqual(viewModel.UserScores[0].ScoreId, 1);
        Assert.AreEqual(viewModel.CurrentEntry.MovieId, viewModel.UserScores[0].ScoreId);
    }
}