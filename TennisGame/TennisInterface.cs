using System;

namespace TennisGame
{
    public class TennisInterface
    {
        public static void Run()
        {
            Console.Write("Enter the name of the server: ");
            string serverName = Console.ReadLine();

            Console.Write("Enter the name of the receiver: ");
            string receiverName = Console.ReadLine();

            Player server = new Player(serverName);
            Player receiver = new Player(receiverName);

            Game game = new Game(server, receiver);

            Console.WriteLine();
            Console.WriteLine("Welcome to our tennis game with arrow-key scoring!");
            Console.WriteLine($"Server: {server.GetName()}");
            Console.WriteLine($"Receiver: {receiver.GetName()}");
            Console.WriteLine();
            Console.WriteLine("Use the arrow keys to award points:");
            Console.WriteLine("    Up Arrow => Server");
            Console.WriteLine("    Down Arrow => Receiver");
            Console.WriteLine("Press the Escape (Esc) key anytime to quit.");
            Console.WriteLine();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    game.Point_To(server);
                    Console.WriteLine("Point -> " + server.GetName());
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    game.Point_To(receiver);
                    Console.WriteLine("Point -> " + receiver.GetName());
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\nExiting the game...");
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
                    string winnerName = game.GetLeadPlayer().GetName();
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

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
