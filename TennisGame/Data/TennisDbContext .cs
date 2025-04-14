using Microsoft.EntityFrameworkCore;
using TennisGame.Models;

namespace TennisGame.Data
{
    public class TennisDbContext : DbContext
    {
        public DbSet<GameResult> GameResults { get; set; }

        public TennisDbContext(DbContextOptions<TennisDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameResult>().ToTable("TennisScores");
            base.OnModelCreating(modelBuilder);
        }
    }
}
