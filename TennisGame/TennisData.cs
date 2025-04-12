using System.Data.SqlClient;

namespace TennisGame
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
            // Using ADO.NET with parameterized query for security
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = @"
                    INSERT INTO TennisScores
                        (ServerName, ReceiverName, ServerScore, ReceiverScore, Winner)
                    VALUES
                        (@ServerName, @ReceiverName, @ServerScore, @ReceiverScore, @Winner);
                ";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@ServerName", serverName);
                    cmd.Parameters.AddWithValue("@ReceiverName", receiverName);
                    cmd.Parameters.AddWithValue("@ServerScore", serverScore);
                    cmd.Parameters.AddWithValue("@ReceiverScore", receiverScore);
                    cmd.Parameters.AddWithValue("@Winner", winner);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
