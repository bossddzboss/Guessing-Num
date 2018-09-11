using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing_Num
{
    class Program
    {
        
        static void Main(string[] args)
        {
            dev();

            int rMin = 0;
            int rMax = 0;
            GuessGame game = new GuessGame();
            
            string userName = user();
            do {
                GetMinAndMaxNumber(out rMin, out rMax);

                game.SetupGame(userName, rMin, rMax);

                PrintNumber(game.Min, game.Max);
                int guess = 0;
                //System.Nullable<int> guess = null;
                var correct = false;

                do
                {
                    // รับเลขทายจาก user
                    guess = getGuessInt();

                    // ตรวจสอบเลข
                    try
                    {
                        correct = game.IsCorrect(guess);
                    }
                    catch (GameException ge)
                    {
                        Console.WriteLine($"{Environment.NewLine}{ge.Message}");
                        correct = false;
                    }
                } while (!correct);

                ColorMes(ConsoleColor.Green, $"CORRECT{Environment.NewLine}");

                // ต้องการเล่นต่อหรือไม่?
                bool con2 = AskContinue(game.GetCorrect());//valid char input
                if (con2 == false)//valid play again
                {//yes to continue
                    break;
                }                
            } while (true);
        }
        static void dev()
        {
            Console.WriteLine($"Guessing Number game V.1.0.0{Environment.NewLine}by Boss{Environment.NewLine}===========================");
        }
        static string user()
        {
            Console.WriteLine("What your name?");
            string playerName = Console.ReadLine();
            Console.WriteLine($"{Environment.NewLine}Hello {playerName}{Environment.NewLine}");
            return playerName;
        }


        static int getGuessInt()
        {            
            int result = 0;
            var isValid = false;
            do
            {
                var input = Console.ReadLine();
                isValid = int.TryParse(input, out result);
                if (!isValid)//valid string to int
                {
                    ColorMes(ConsoleColor.White, "please enter number");
                }
            } while (!isValid);

            return result;
        }

        static int? getGuess(string input)
        {
            int? result = null;
            var tmp = 0;            
            if (!int.TryParse(input, out tmp))//valid string to int
            {
                ColorMes(ConsoleColor.White, "please enter number");
            }
            else
            {
                result = tmp;
            }
            return result;
        }
        static int checkNumber(string word)
        {
            var rMin = 0;
            do
            {
                var input = Console.ReadLine();
                if (!int.TryParse(input, out rMin))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                    Console.Write($"{word} range is:");
                }
                else
                {
                    break;
                }
            } while (true);
            return rMin;
        }
        static bool AskContinue(int correct)
        {
            do
            {
                var answer = string.Empty; // ""
                Console.WriteLine("play again Y/N (Y)");
            answ:
                answer = Console.ReadLine().ToUpper();
                if (answer == "Y" || string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine($"{Environment.NewLine}Enter number"); 
                   break;//exit do loop
                }
                else if (answer == "N")
                {                    
                    Console.WriteLine($"{Environment.NewLine}Correct number is {correct}");
                    Console.WriteLine("Press enter to exit");
                    Console.ReadKey();                   
                    return false ;//exit function
                }
                else
                {
                    Console.WriteLine("Please enter Y or N"); ;
                    goto answ;
                }

            } while (true);
            return true;//if continue           
        }
        static void GetMinAndMaxNumber(out int rMin, out int rMax)
        {
        
            Console.Write("Minimum range is:");
            //check number min
            rMin = checkNumber("Minimum");
        Max://set Max point
            Console.Write("Maximum range is:");
            //check number max
            rMax = checkNumber("Maximum");
            //check min max
            if (rMin == rMax)
            {
                Console.WriteLine("cant be same number");
                //go to Max point
                goto Max;
            }
            else if (rMin > rMax || rMax < rMin)
            {
                Console.WriteLine("Max num cant lower than min num");
                goto Max;
            }
            //print range number            
            Console.WriteLine($"{Environment.NewLine}Range of number : {rMin}-{rMax}");
        }
        static void ColorMes(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(Environment.NewLine + message);
            Console.ResetColor();
        }
        static void PrintNumber(int rMin, int rMax)
        {
            for (int i = rMin; i <= rMax; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine($"{ Environment.NewLine}");            
        }
        private static int GetRandomNumber(int rMin, int rMax)
        {
            Random random = new Random();
            int correct = random.Next(rMin, rMax);
            return correct;
        }
    }
}