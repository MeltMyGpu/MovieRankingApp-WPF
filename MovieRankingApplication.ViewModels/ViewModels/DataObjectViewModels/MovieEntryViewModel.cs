using MovieRankingApplication.Model.Generated;
using MovieRankingApplication.MvvmHelpers;
using MovieRankingApplication.ViewModels.Interfaces;


namespace MovieRankingApplication.ViewModels.DataObjectViewModels
{
    public class MovieEntryViewModel : BindableBase, IMovieEntryViewModel
    {
        private MovieEntry _movieEntry;
        private bool _isModified = false;

        public MovieEntryViewModel(MovieEntry movieEntry = null) => this._movieEntry = movieEntry ?? new MovieEntry();

        public bool IsModified { get => _isModified ; }
        public MovieEntry Model { get => _movieEntry; }

        public long MovieId
        {
            get => _movieEntry.MovieId;

            set
            {
                if (_movieEntry.MovieId != value)
                {
                    _movieEntry.MovieId = value;
                    OnPropertyChanged();
                    _isModified = true;
                }
            }
        }

        public string MovieName
        {
            get => _movieEntry.MovieName;
            set
            {
                if (_movieEntry.MovieName != value)
                {
                    _movieEntry.MovieName = value;
                    OnPropertyChanged();
                    _isModified = true;
                }
            }
        }

        public string MovieGenre
        {
            get => _movieEntry.MovieGenre;
            set
            {
                if (_movieEntry.MovieGenre != value)
                {
                    _movieEntry.MovieGenre = value;
                    OnPropertyChanged();
                    _isModified = true;
                }
            }
        }
        public long MovieTotalScore
        {
            get => _movieEntry.MovieTotalScore;
            set
            {
                if (_movieEntry.MovieTotalScore != value)
                {
                    _movieEntry.MovieTotalScore = value;
                    OnPropertyChanged();
                    _isModified = true;
                }
            }
        }

    }
}
