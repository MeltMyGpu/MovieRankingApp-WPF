using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace MovieRankingApplication.Model.Generated
{
    public interface IMovieRankingDatabaseContext
    {
        // Temp interface for current setup
        DbSet<MovieEntry> MovieEntries { get; set; }
        DbSet<UserScore> UserScores { get; set; }
        void DoSaveChanges();
    }

    public partial class MovieRankingDatabaseContext : DbContext, IMovieRankingDatabaseContext
    {
        public MovieRankingDatabaseContext()
        {
        }

        public MovieRankingDatabaseContext(DbContextOptions<MovieRankingDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MovieEntry> MovieEntries { get; set; } = null!;
        public virtual DbSet<UserScore> UserScores { get; set; } = null!;

        public void DoSaveChanges()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=E:\\Code\\Project libary\\C#\\MovieRankingApp-WPF\\MovieRankingApplication.Model\\MovieRankingDatabase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieEntry>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.ToTable("MovieEntry");

                entity.HasIndex(e => e.MovieId, "IX_MovieEntry_MovieId")
                    .IsUnique();
            });

            modelBuilder.Entity<UserScore>(entity =>
            {
                entity.HasKey(e => e.ScoreId);

                entity.ToTable("UserScore");

                entity.HasIndex(e => e.ScoreId, "IX_UserScore_ScoreId")
                    .IsUnique();

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.UserScores)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
