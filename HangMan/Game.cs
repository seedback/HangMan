using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows;

namespace HangMan
{
    internal class Game
    {
        static Game()
        {
            StageList.Add((string)
                          "     ____\n" +
                          "    |/\n" +
                          "    |\n" +
                          "    |\n" +
                          "    |\n" +
                          "    |\n" +
                          "   /|\\\n" +
                          "__/_|_\\______\n"
            );
            StageList.Add((string)
                          "     ____\n" +
                          "    |/   |\n" +
                          "    |\n" +
                          "    |\n" +
                          "    |\n" +
                          "    |\n" +
                          "   /|\\\n" +
                          "__/_|_\\______\n"
            );
            StageList.Add((string)
                          "     ____\n" +
                          "    |/   |\n" +
                          "    |   (_)\n" +
                          "    |\n" +
                          "    |\n" +
                          "    |\n" +
                          "   /|\\\n" +
                          "__/_|_\\______\n"
            );
            StageList.Add((string)
                          "     ____\n" +
                          "    |/   |\n" +
                          "    |   (_)\n" +
                          "    |    |\n" +
                          "    |\n" +
                          "    |\n" +
                          "   /|\\\n" +
                          "__/_|_\\______\n"
            );
            StageList.Add((string)
                          "     ____\n" +
                          "    |/   |\n" +
                          "    |   (_)\n" +
                          "    |   /|\n" +
                          "    |\n" +
                          "    |\n" +
                          "   /|\\\n" +
                          "__/_|_\\______\n"
            );
            StageList.Add((string)
                          "     ____\n" +
                          "    |/   |\n" +
                          "    |   (_)\n" +
                          "    |   /|\\\n" +
                          "    |\n" +
                          "    |\n" +
                          "   /|\\\n" +
                          "__/_|_\\______\n"
            );
            StageList.Add((string)
                          "     ____\n" +
                          "    |/   |\n" +
                          "    |   (_)\n" +
                          "    |   /|\\\n" +
                          "    |    |\n" +
                          "    |\n" +
                          "   /|\\\n" +
                          "__/_|_\\______\n"
            );
            StageList.Add((string)
                          "     ____\n" +
                          "    |/   |\n" +
                          "    |   (_)\n" +
                          "    |   /|\\\n" +
                          "    |    |\n" +
                          "    |   /\n" +
                          "   /|\\\n" +
                          "__/_|_\\______\n"
            );
            StageList.Add((string)
                          "     ____\n" +
                          "    |/   |\n" +
                          "    |   (_)\n" +
                          "    |   /|\\\n" +
                          "    |    |\n" +
                          "    |   / \\\n" +
                          "   /|\\\n" +
                          "__/_|_\\______\n"
            );
        }

        public static void Setup()
        {
            Word = ChooseWord().ToUpper();

            ShownWord = String.Empty;
            foreach (char c in Word)
            {
                if (c == ' ')
                {
                    ShownWord = ShownWord.Insert(ShownWord.Length, " ");
                    continue;
                }
                ShownWord = ShownWord.Insert(ShownWord.Length, "_");
            }
            UsedLetters = "";
        }

        public static bool PrintStage(int stage)
        {
            Console.Clear();
            if (stage >= 0 && stage < StageList.Count-1)
            {
                Console.WriteLine(StageList[stage]);
                return true;
            }
            else if(stage < StageList.Count)
            {
                Console.WriteLine(StageList[stage]);
            }

            return false;
        }

        public static bool CheckLetterIsNew(char letter)
        {
            letter = Convert.ToChar(Convert.ToString(letter).ToUpper());
            foreach (char usedLetter in UsedLetters)
            {
                if (usedLetter == letter)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckLetter(char letter)
        {
            bool isIncluded = false;

            letter = Convert.ToChar(Convert.ToString(letter).ToUpper());

            UsedLetters = UsedLetters.Insert(UsedLetters.Length, Convert.ToString(letter));
            for (int i = 0; i < Word.Length; i++)
            {
                if (Word[i] == letter)
                {
                    ShownWord = ShownWord.Remove(i, 1);
                    ShownWord = ShownWord.Insert(i, Convert.ToString(letter));
                    isIncluded = true;
                }
            }
            return isIncluded;
        }

        public static string ChooseWord()
        {
            string path = Directory.GetCurrentDirectory() + "\\words.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("No word.txt file was found at " + path);
                return "";
            }

            string[] lines = File.ReadAllLines(path, Encoding.Latin1);
            Random r = new Random();
            int randomLineNumber = r.Next(0, lines.Length - 1);
            string line = lines[randomLineNumber];
            return line;
        }

        public static void PrintBoard(int i)
        {
            if (i == -1)
            {
                i = StageList.Count-1;
            }

            Console.Clear();
            PrintStage(i);
            //Console.WriteLine(Game.Word);
            Console.WriteLine(Game.ShownWord);
            Console.WriteLine(Game.UsedLetters);
        }

        public static List<string> StageList = new List<string>();

        public static string Word = "";
        public static string ShownWord = "";
        public static string UsedLetters = "";
    }
}
