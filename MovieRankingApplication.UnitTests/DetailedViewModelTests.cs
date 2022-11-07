using MovieRankingApplication.ViewModels;
using MovieRankingApplication.ViewModels.PageViewModels;
using Moq;
using Microsoft.EntityFrameworkCore;
using MovieRankingApplication.Model.Generated;

namespace MovieRankingApplication.UnitTests
{
    [TestClass]
    public class DetailedViewModelTests
    {

        [TestMethod]
        public void Load_In_NewMode()
        {
            // fake data for mock sets
            var userData = new List<UserScore>{
                new UserScore()
            }.AsQueryable();
            var movieData = new List<MovieEntry>()
            {
                new MovieEntry()
            }.AsQueryable();

            // Creates and setup Mock Objects
            var mockMWViewM = new Mock<MainWindowViewModel>("Test1","Test2");

            // Enable mock sets to provide mock data from the fake data lits.
            var mockset = new Mock<DbSet<UserScore>>();
            mockset.As<IQueryable<UserScore>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockset.As<IQueryable<UserScore>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockset.As<IQueryable<UserScore>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockset.As<IQueryable<UserScore>>().Setup(m => m.GetEnumerator()).Returns(() => userData.GetEnumerator());

            var mockset2 = new Mock<DbSet<MovieEntry>>();
            mockset2.As<IQueryable<MovieEntry>>().Setup(m => m.Provider).Returns(movieData.Provider);
            mockset2.As<IQueryable<MovieEntry>>().Setup(m => m.Expression).Returns(movieData.Expression);
            mockset2.As<IQueryable<MovieEntry>>().Setup(m => m.ElementType).Returns(movieData.ElementType);
            mockset2.As<IQueryable<MovieEntry>>().Setup(m => m.GetEnumerator()).Returns(() => movieData.GetEnumerator());

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
}