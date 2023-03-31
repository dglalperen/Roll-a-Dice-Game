using System;

namespace DiceRollRaceTo100
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int playerScore = 0;
            int computerScore = 0;
            int targetScore = 100;

            Console.WriteLine("Willkommen!");
            Console.WriteLine("Spielregeln:");
            Console.WriteLine("Der erste der 100 Punkte sammelt gewinnt! Würfelst du eine 1, ist dein Gegner dran.");


            while (playerScore < targetScore && computerScore < targetScore)
            {
                Console.WriteLine($"\nAktueller Punktestand - Spieler: {playerScore}, Computer: {computerScore}");
                Console.WriteLine($"-----------------------------------");

                playerScore += PlayerTurn();
                if (playerScore >= targetScore)
                {
                    Console.WriteLine($"Glückwunsch! Du hast mit {playerScore} das Spiel gewonnen!");
                    break;
                }

                computerScore += ComputerTurn();
                if (computerScore >= targetScore)
                {
                    Console.WriteLine($"Der Computer hat mit {computerScore} Punkten gewonnen!");
                }
            }

            Console.WriteLine("Danke fürs Spielen!");
        }

        static int PlayerTurn()
        {
            int turnScore = 0;
            int rollCount = 0;

            while (rollCount < 5 && turnScore < 20)
            {
                int roll = RollDice();
                Console.WriteLine($"Du hast eine {roll} gewürfelt");
                rollCount++;

                if (roll == 1)
                {
                    Console.WriteLine("Du hast alle deine Punkte verloren!");
                    Console.WriteLine($"-----------------------------------");

                    return 0;
                }

                turnScore += roll;

                if (turnScore >= 20)
                {
                    Console.WriteLine($"Du hast {turnScore} Punkte in dieser Runde gemacht. Die Runde ist vorbei.");
                    break;
                }

                if (rollCount < 5)
                {
                    Console.WriteLine($"Dein Aktueller Punktestand ist {turnScore}. Möchtest du nochmal würfeln (y/n)");
                    string response = Console.ReadLine().ToLower();
                    if (response != "y" && response != "yes")
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"-----------------------------------");
            return turnScore;
        }

        static int ComputerTurn()
        {
            int turnScore = 0;

            for (int i = 0; i < 2; i++)
            {
                int roll = RollDice();
                Console.WriteLine($"Der Computer hat eine {roll} gewürfelt");

                if (roll == 1)
                {
                    Console.WriteLine("Der Computer hat alle seine Punkte verloren!");
                    return 0;
                }

                turnScore += roll;
            }

            Console.WriteLine($"Der Computer hat einen Punktestand von {turnScore}");
            Console.WriteLine($"-----------------------------------");

            return turnScore;
        }

        static int RollDice()
        {
            return random.Next(1, 7);
        }
    }
}
