enum Choice { Invalid = -1, Rock = 1, Paper = 2, Scissors = 3 }
class Program
{
    static Choice GetChoice(string player)
    {
        Console.Write(player + ", Please choose: 1 for Rock, 2 for Paper, 3 for Scissors: ");
        while (true)
        {
           string input = Console.ReadLine()?.Trim();
            if (input == "exit") return Choice.Invalid;
            if (Enum.TryParse(input, true, out Choice choice) && Enum.IsDefined(typeof(Choice), choice))
                return choice;
            Console.Write("Invalid choice, please try again: ");

        }
    }
    static string DetermineWinner(Choice p1, Choice p2, ref int player1Wins, ref int player2Wins, ref int ties)
    { 
        if(p1 == p2)
        {
            ties++;
            return "its a tie";   
        }
        if ((p1 == Choice.Rock) && (p2 == Choice.Scissors) ||
            (p1 == Choice.Paper) && (p2 == Choice.Rock) ||
            (p1 == Choice.Scissors) && (p2 == Choice.Paper))
        {
            player1Wins++;
            return "COngratulations, Player 1 wins";
                
        }
        player2Wins++;
        return "Congratulations, Player 2 wins";

    }
    static bool GetYesOrNo()
    {
        while (true)
        {
            Console.Write("Do you want to contine, choose 1 for Yes, 2 for No: ");
            string input = Console.ReadLine()?.Trim();
            if (input == "1") return true;
            if (input == "2") return false;
            Console.WriteLine("Invalid input, please enter 1 for YES or 2 for NO: ");

        }
    }
    static void Main()
    {
        Console.WriteLine("WELCOME TO JECY GAMING CENTER \n");

        List<string> History = new List<string>();
        int player1Wins = 0, player2Wins = 0, ties = 0;

        while (true)
        {
            Choice player1 = GetChoice("Player 1");
            if (player1 == Choice.Invalid) break;

            Choice player2 = GetChoice("Player 2");
            if (player2 == Choice.Invalid) break;

            string result = DetermineWinner(player1, player2, ref player1Wins, ref player2Wins, ref ties);
            History.Add($"Player 1: {player1}, Player 2: {player2} => {result}");
            Console.WriteLine(result);

            if (!GetYesOrNo())
            {
                Console.WriteLine("\n ------GAME HISTORY------");

                foreach (string res in History)
                {
                    Console.WriteLine(res);
                }
                Console.WriteLine($"\n--TOTAL ROUNDS--: {History.Count}, --PLAYER 1 WINS--: {player1Wins}, --PLAYER 2 WINS-- {player2Wins}, --TIES-- {ties}");

                Console.WriteLine("\n Thank you for playing!\nSEE YOU SOME OTHER TIME");
                break;

            }

        }
    }
}
     
