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

                for (int i = 0; Game.PrintStage(i); i++)
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    Game.PrintBoard(i);

                    bool isFinished = false;
                    string input = "";

                    while (!isFinished)
                    {
                        Game.PrintBoard(i);
                        input = Console.ReadLine();
                        if (input == String.Empty)
                        {
                            continue;
                        }

                        isFinished = Game.CheckLetterIsNew(input[0]);
                    }

                    if (Game.CheckLetter(input[0]))
                    {
                        i--;
                    }

                    if (Game.Word == Game.ShownWord)
                    {
                        break;
                    }
                }

                Game.PrintBoard(-1);
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
