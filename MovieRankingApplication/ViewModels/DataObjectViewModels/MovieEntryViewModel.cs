using MovieRankingApplication.Model.Context;
using MovieRankingApplication.MvvmHelpers;
using MovieRankingApplication.ViewModels.Interfaces;


namespace MovieRankingApplication.ViewModels.DataObjectViewModels
{
    public class MovieEntryViewModel : BindableBase, IMovieEntryViewModel
    {
        private MovieEntry _movieEntry;

        public MovieEntryViewModel(MovieEntry movieEntry)
        {
            this._movieEntry = movieEntry;
        }

        public long MovieId
        {
            get => _movieEntry.MovieId;

            set
            {
                if (_movieEntry.MovieId != value)
                {
                    _movieEntry.MovieId = value;
                    OnPropertyChanged();
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
                }
            }
        }

    }
}
