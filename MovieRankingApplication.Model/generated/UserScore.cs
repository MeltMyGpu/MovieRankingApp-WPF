using System;
using System.Collections.Generic;

namespace MovieRankingApplication.Model.generated
{
    public partial class UserScore
    {
        public long ScoreId { get; set; }
        public long MovieId { get; set; }
        public string UserName { get; set; } = null!;
        public string ActingScore { get; set; } = null!;
        public string CharacterScore { get; set; } = null!;
        public string CinematographyScore { get; set; } = null!;
        public string PlotScore { get; set; } = null!;
        public string TotalScore { get; set; } = null!;

        public virtual MovieEntry Movie { get; set; } = null!;
    }
}
