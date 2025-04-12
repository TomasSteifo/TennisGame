using System.Collections.Generic;

namespace TennisGame
{
    public class Player
    {
        private int score;
        public List<string> pointsDescription = new List<string> { "Love", "Fifteen", "Thirty", "Forty" };

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

        public string GetScoreDescription()
        {
            if (score >= pointsDescription.Count)
            {
                // Return last label if beyond range to avoid out-of-bounds 
                return pointsDescription[pointsDescription.Count - 1];
            }
            return pointsDescription[score];
        }
    }
}
