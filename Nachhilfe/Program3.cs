namespace ConsoleUI
{
    class Programm
    {
        static void Main2(string[] args)
        {
            const int MAX_POINTS = 100;
            int gamerDiceCount = 0; // Aktuelle Gesamtpunktzahl
            int refereeDiceCount = 0;

            Console.WriteLine("---Spielstart---");
            Console.WriteLine("Hallo Spieler oder Spielerin");

            Console.WriteLine("Du beginnst...");
            gamerDiceCount = PlayOneSet();
            Console.WriteLine($"Der Spieler hat {gamerDiceCount} Punkte");
        }

        public static int GetRandomDice()
        {
            Random randomNumberGenerator = new Random();

            return randomNumberGenerator.Next(1, 6);
        }

        public static int PlayOneSet()
        {
            int rolledPoints = 0; // Anzahl der gesammelten Punkte
            int rolledDices = 0; // Anzahl der gewürfelten Würfel
            int rolledDice; // Aktuell gewürfelte Zahl
            string gamerInput = "";
            bool roundOver = false;

            // Würfeln
            rolledDice = GetRandomDice();

            while (!roundOver && rolledDice > 1 && rolledDices < 6 && rolledPoints < 20)
            {
                Console.WriteLine($"Der Spieler würfelte eine {rolledDice}");
                Console.WriteLine("\n");
                Console.WriteLine("Möchtest Sie weiterwürfeln?");
                Console.WriteLine("Geben Sie ja oder nein ein!");
                Console.WriteLine("\n");

                gamerInput = Console.ReadLine();
                switch (gamerInput)
                {
                    case "ja":
                        rolledPoints += rolledDice;
                        rolledDice = GetRandomDice();
                        rolledDices += 1;
                        Console.WriteLine($"Aktueller Stand: {rolledPoints}");
                        Console.WriteLine($"\n");

                        break;
                    case "nein":
                        roundOver = true;
                        return rolledPoints;
                    default:
                        Console.WriteLine("Geben Sie ja oder nein ein!");
                        break;
                }
            }

            Console.WriteLine("Round over, 0 Punkte");
            return 0;
        }
    }
}