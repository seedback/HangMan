using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Channels;


namespace HangMan
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Game.Setup();
                int stage = 0;

                for (stage = 0; Game.PrintStage(stage); stage++)
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    Game.PrintBoard(stage);

                    bool isFinished = false;
                    string input = "";

                    while (!isFinished)
                    {
                        Game.PrintBoard(stage);
                        input = Console.ReadLine();
                        if (input == String.Empty)
                        {
                            continue;
                        }

                        isFinished = Game.CheckLetterIsNew(input[0]);
                    }

                    if (Game.CheckLetter(input[0]))
                    {
                        stage--;
                    }

                    if (Game.Word == Game.ShownWord)
                    {
                        break;
                    }
                }

                Game.PrintBoard(stage);
                Console.WriteLine();

                if (Game.Word == Game.ShownWord)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("That is correct!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("You lost!");
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Do you want to play again? (y/n)");
                string quitAnswer;
                while (true)
                {
                    quitAnswer = Console.ReadLine() ?? String.Empty;
                    if (quitAnswer.ToUpper() == "Y" || quitAnswer.ToUpper() == "N")
                    {
                        break;
                    }
                }

                if (quitAnswer.ToUpper() == "N")
                {
                    break;
                }
            }
        }
    }
}
