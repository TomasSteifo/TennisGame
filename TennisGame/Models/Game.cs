using System;

namespace TennisGame.Models
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

        public string MethodToGetCurrentMatchScore()
        {
            int serverScore = server.MethodToGetPlayerScore();
            int receiverScore = receiver.MethodToGetPlayerScore();

            if (serverScore >= 4 || receiverScore >= 4)
            {
                int diff = Math.Abs(serverScore - receiverScore);

                if (diff >= 2)
                {
                    return "Score: Game, " + ThisMethodChecksWhichPlayerHasTheHighestScore().MehtodToGetPlayerName();
                }
                else if (diff == 0)
                {
                    return "Score: Deuce";
                }
                else
                {
                    return "Score: Advantage, " + ThisMethodChecksWhichPlayerHasTheHighestScore().MehtodToGetPlayerName();
                }
            }

            return "Score: " + server.ThisIsAHelperMethodToConvertScoreToTennisTerm() + ", " + receiver.ThisIsAHelperMethodToConvertScoreToTennisTerm();
        }

        public Player ThisMethodChecksWhichPlayerHasTheHighestScore()
        {
            return server.MethodToGetPlayerScore() > receiver.MethodToGetPlayerScore() ? server : receiver;
        }

        public void MethodToSeeWhoGetsAPoint(Player player)
        {
            player.MethodToAddPoint();
        }
    }
}
