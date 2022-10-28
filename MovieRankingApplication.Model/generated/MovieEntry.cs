using System;
using System.Collections.Generic;

namespace MovieRankingApplication.Model.Generated
{
    public partial class MovieEntry
    {
        public MovieEntry()
        {
            UserScores = new HashSet<UserScore>();
        }

        public long MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public string MovieGenre { get; set; } = null!;
        public long MovieTotalScore { get; set; }

        public virtual ICollection<UserScore> UserScores { get; set; }
    }
}
