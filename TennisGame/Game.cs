using System;

namespace TennisGame
{
    public class Game
    {
        private Player server;
        private Player receiver;

        public Game(Player server, Player receiver)
        {
            this.server = server;
            this.receiver = receiver;
        }

        public string GetMatchScore()
        {
            int serverScore = server.GetPlayerScore();
            int receiverScore = receiver.GetPlayerScore();

            // If either player has 4 or more points, check differences
            if (serverScore >= 4 || receiverScore >= 4)
            {
                int diff = Math.Abs(serverScore - receiverScore);

                // If difference >= 2, we have a winner
                if (diff >= 2)
                {
                    return "Score: Game, " + GetLeadPlayer().GetName();
                }
                else if (diff == 0)
                {
                    return "Score: Deuce";
                }
                else
                {
                    return "Score: Advantage, " + GetLeadPlayer().GetName();
                }
            }
            // Otherwise, use the standard 0-3 descriptions
            return "Score: " + server.GetScoreDescription() + ", " + receiver.GetScoreDescription();
        }

        public Player GetLeadPlayer()
        {
            return (server.GetPlayerScore() > receiver.GetPlayerScore()) ? server : receiver;
        }

        public void Point_To(Player player)
        {
            player.AddPoint();
        }
    }
}
