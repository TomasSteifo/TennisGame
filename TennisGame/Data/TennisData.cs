using Microsoft.EntityFrameworkCore;
using TennisGame.Models;

namespace TennisGame.Data
{
    public static class TennisData
    {
        public static void SaveGameResult(
            string connectionString,
            string serverName,
            string receiverName,
            int serverScore,
            int receiverScore,
            string winner)
        {
            // Create a DbContext (if you’re not using dependency injection)
            var optionsBuilder = new DbContextOptionsBuilder<TennisDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=PC\\SQLEXPRESS;Database=TennisScores;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"
            );
            using (var context = new TennisDbContext(optionsBuilder.Options))
            {
                // Build the object to save
                var result = new GameResult
                {
                    ServerName = serverName,
                    ReceiverName = receiverName,
                    ServerScore = serverScore,
                    ReceiverScore = receiverScore,
                    Winner = winner,
                    PlayedOn = DateTime.Now
                };

                // Add and save
                context.GameResults.Add(result);
                context.SaveChanges();
            }
        }
    }
}

