using MovieRankingApplication.ViewModels.Interfaces;
using System.Windows.Input;

namespace MovieRankingApplication.ViewModels.Interfaces
{
    public interface IDetailedViewModel
    {
        IMovieEntryViewModel CurrentEntry { get; set; }
        ICommand DoResetChanges { get; }
        ICommand DoSaveChanges { get; }
        IList<IUserScoreViewModel> UserScores { get; set; }
    }
}