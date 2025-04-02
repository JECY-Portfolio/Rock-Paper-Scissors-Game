enum Choice { Rock = 1, Paper = 2, Scissors = 3 }

class Program
{
    static Choice GetChoice(string player)
    {
        Console.Write(player + ", Please choose: 1 for Rock, 2 for Paper, 3 for Scissors: ");
        while (true)
        {
            if (Enum.TryParse(Console.ReadLine(), true, out Choice choice) && Enum.IsDefined(typeof(Choice), choice))
                return choice;
            Console.Write("Invalid choice, please try again: ");
        }
    }

    static string DetermineWinner(Choice p1, Choice p2)
    {
        if (p1 == p2)
            return "It's a tie.";

        if ((p1 == Choice.Rock && p2 == Choice.Scissors) ||
            (p1 == Choice.Paper && p2 == Choice.Rock) ||
            (p1 == Choice.Scissors && p2 == Choice.Paper))
            return "Congratulations, Player 1 wins!";

        return "Congratulations, Player 2 wins!";
    }

    static void Main()
    {
        Console.WriteLine("WELCOME TO JECY GAMING CENTER \n");

        List<string> History = new List<string>();

        while (true)
        {
            Choice player1 = GetChoice("Player 1");
            Choice player2 = GetChoice("Player 2");

            string result = DetermineWinner(player1, player2);
            History.Add(result);

            Console.WriteLine(result);

            string input;
            while (true)
            {
                Console.Write("Do you want to continue? (1 for Yes, 2 for No): ");
                input = Console.ReadLine();

                if (input == "1" || input == "2")
                    break;

                Console.WriteLine("Invalid input! Please enter 1 for Yes or 2 for No.");
            }

            if (input != "1")
            {
                Console.WriteLine("\nGame Over. Here's your history:");
                foreach (string res in History)
                {
                    Console.WriteLine(res);
                }
                break;
            }
        }

        Console.WriteLine("Thank you for playing!\nSEE YOU SOME OTHER TIME");
    }
}
