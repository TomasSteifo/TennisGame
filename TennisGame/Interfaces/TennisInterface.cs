using System;
using TennisGame.Data;
using TennisGame.Models;

namespace TennisGame.Interfaces
{
    public class TennisInterface
    {
        public static void Run()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine(" Who is going to get awarded an intershio at Bilvision? Tennis EFL Championship Game! ");
            Console.WriteLine("******************************************************************************************");
            Console.ResetColor(); 

            Console.Write("Enter the name of the ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("amazing server");
            Console.ResetColor();
            Console.Write(": ");

            string serverName = Console.ReadLine()!;

            Console.Write("Enter the name of the ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("notorious receiver");
            Console.ResetColor();
            Console.Write(": ");

            string receiverName = Console.ReadLine()!;

            Player server = new Player(serverName);
            Player receiver = new Player(receiverName);

            Game game = new Game(server, receiver);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("Are you ready to get an Internship at Bilvision!");
            Console.WriteLine($"The amazing server: {server.MehtodToGetPlayerName()}");
            Console.WriteLine($"The notorious receiver: {receiver.MehtodToGetPlayerName()}");
            Console.WriteLine();
            Console.WriteLine("Instructions to award points:");
            Console.WriteLine("    Up Arrow => Server");
            Console.WriteLine("    Down Arrow => Receiver");
            Console.WriteLine("    Escape (Esc) => End the game");
            Console.WriteLine();
            Console.ResetColor();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    game.MethodToSeeWhoGetsAPoint(server);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Point given to the amazing " + server.MehtodToGetPlayerName());
                    Console.ResetColor();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    game.MethodToSeeWhoGetsAPoint(receiver);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Point given to the notorious " + receiver.MehtodToGetPlayerName());
                    Console.ResetColor();
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Great Job! Nils and Jesper will award you a Monster Energy drink!");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    continue;
                }

                string currentScore = game.MethodToGetCurrentMatchScore();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(currentScore);
                Console.ResetColor();

                if (currentScore.StartsWith("Score: Game"))
                {
                    string winnerName = game.ThisMethodChecksWhichPlayerHasTheHighestScore().MehtodToGetPlayerName();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nGame is finished! Winner: {winnerName}");
                    Console.ResetColor();

                    string connectionString = "Server=PC\\SQLEXPRESS;Database=TennisScores;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

                    TennisData.MethodToSaveGameResult(
                        connectionString,
                        server.MehtodToGetPlayerName(),
                        receiver.MehtodToGetPlayerName(),
                        server.MethodToGetPlayerScore(),
                        receiver.MethodToGetPlayerScore(),
                        winnerName
                    );

                    break;
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for playing! Nils and Jesper will award you a Monster Energy drink.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
