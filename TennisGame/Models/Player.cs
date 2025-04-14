using System.Collections.Generic;

namespace TennisGame.Models
{
    public class Player
    {
        private int score;
        public List<string> thisIsAListOfDiffrentPiontsAwardedInTennis = new List<string> { "Love <3", "Fifteen (15)", "Thirty (30)", "Forty (40)" };

        private string name;

        public Player(string name)
        {
            this.name = name;
        }

        public void MethodToAddPoint()
        {
            score++;
        }

        public int MethodToGetPlayerScore()
        {
            return score;
        }

        public string MehtodToGetPlayerName()
        {
            return name;
        }

        public string ThisIsAHelperMethodToConvertScoreToTennisTerm()
        {
            if (score >= thisIsAListOfDiffrentPiontsAwardedInTennis.Count)
            {
                return thisIsAListOfDiffrentPiontsAwardedInTennis[thisIsAListOfDiffrentPiontsAwardedInTennis.Count - 1];
            }
            return thisIsAListOfDiffrentPiontsAwardedInTennis[score];
        }
    }
}
