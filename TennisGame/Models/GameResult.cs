using TennisGame.Models;


namespace TennisGame.Models
{
    public class GameResult
    {
        public int Id { get; set; }
        public string? ServerName { get; set; }
        public string? ReceiverName { get; set; }
        public int ServerScore { get; set; }
        public int ReceiverScore { get; set; }
        public string? Winner { get; set; }
        public DateTime PlayedOn { get; set; } = DateTime.Now;
    }
}
