using Microsoft.EntityFrameworkCore;
using TennisGame.Models;

namespace TennisGame.Data
{
    public static class TennisData
    {
        public static void MethodToSaveGameResult(
            string connectionString,
            string serverName,
            string receiverName,
            int serverScore,
            int receiverScore,
            string winner)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TennisDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=PC\\SQLEXPRESS;Database=TennisScores;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"
            );
            using (var context = new TennisDbContext(optionsBuilder.Options))
            {
                var result = new GameResult
                {
                    ServerName = serverName,
                    ReceiverName = receiverName,
                    ServerScore = serverScore,
                    ReceiverScore = receiverScore,
                    Winner = winner,
                    PlayedOn = DateTime.Now
                };

                context.GameResults.Add(result);
                context.SaveChanges();
            }
        }
    }
}

