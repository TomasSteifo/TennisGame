using System;

namespace TennisGame
{
    public class TennisInterface
    {
        public static void Run()
        {
            Console.Write("Enter the name of the amazing server: ");
            string serverName = Console.ReadLine();

            Console.Write("Enter the name of the notorious receiver: ");
            string receiverName = Console.ReadLine();

            Player server = new Player(serverName);
            Player receiver = new Player(receiverName);

            Game game = new Game(server, receiver);

            Console.WriteLine();
            Console.WriteLine("Lets see who the best tennis player is! The winner will be awarded a Internship at Bilvision");
            Console.WriteLine($"The amazing server: {server.GetName()}");
            Console.WriteLine($"The notorious receiver: {receiver.GetName()}");
            Console.WriteLine();
            Console.WriteLine("Instructions to award points");
            Console.WriteLine("    Up Arrow => Server");
            Console.WriteLine("    Down Arrow => Receiver");
            Console.WriteLine("Escape (Esc) to end the game");
            Console.WriteLine();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    game.Point_To(server);
                    Console.WriteLine("Point given to the amazing " + server.GetName());
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    game.Point_To(receiver);
                    Console.WriteLine("Point given to the notorious " + receiver.GetName());
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\nThank you for playing and now Nils and Jesper will award you a monster energy drink");
                    break;
                }
                else
                {
                    continue; 
                }

                string currentScore = game.GetMatchScore();
                Console.WriteLine(currentScore);

                if (currentScore.StartsWith("Score: Game"))
                {
                    string winnerName = game.ThisMethodChecksWhichPlayerHasTheHighestScore().GetName();
                    Console.WriteLine("\nGame is finished! Winner: " + winnerName);

                    string connectionString = "Server=PC\\SQLEXPRESS;Database=TennisScores;Trusted_Connection=True;";

                    TennisData.SaveGameResult(
                        connectionString,
                        server.GetName(),
                        receiver.GetName(),
                        server.GetPlayerScore(),
                        receiver.GetPlayerScore(),
                        winnerName
                    );

                    break;
                }
            }

            Console.WriteLine("\nThank you for playing and now Nils and Jesper will award you a monster energy drink");
            Console.ReadKey();
        }
    }
}
