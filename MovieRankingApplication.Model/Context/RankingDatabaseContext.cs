using Microsoft.EntityFrameworkCore;

namespace MovieRankingApplication.Model.Context;

public class RankingDatabaseContext : DbContext
{

	public RankingDatabaseContext()
	{

	}

	public RankingDatabaseContext(DbContextOptions<RankingDatabaseContext> options)
		: base(options)
	{

	}

	public virtual DbSet<MovieEntry> MovieEntries { get; set; }
	public virtual DbSet<UserScore> UserScores { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("DataSource=E:\\Code\\Project libary\\C#\\MovieRankingApp-WPF\\MovieRankingApplication.Model\\MovieRankingDatabase.db");
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

			entity.HasIndex(e => e.ScoreId, "IX_UserScore_ScoreId");

			entity.HasOne(d => d.MovieEntry)
				.WithMany(p => p.UserScores)
				.HasForeignKey(d => d.MovieId)
				.OnDelete(DeleteBehavior.ClientSetNull);
		});

		//OnModelCreatingPartial(modelBuilder);
	}

	//partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
