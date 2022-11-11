using System;
using System.Collections.Generic;

namespace MovieRankingApplication.Model.Generated
{
    public partial class UserScore
    {
        public long ScoreId { get; set; }
        public long MovieId { get; set; }
        public string UserName { get; set; } = null!;
        public long ActingScore { get; set; } 
        public long CharacterScore { get; set; } 
        public long CinematographyScore { get; set; } 
        public long PlotScore { get; set; } 
        public long TotalScore { get; set; } 

        public virtual MovieEntry Movie { get; set; } = null!;
    }
}
