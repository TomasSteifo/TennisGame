using System.Collections.Generic;

namespace TennisGame
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

        public void AddPoint()
        {
            score++;
        }

        public int GetPlayerScore()
        {
            return score;
        }

        public string GetName()
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
