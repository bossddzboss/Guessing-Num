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
            int guess = 0;
            int rMin = 0;
            int rMax = 0;
            int k = 0;

            dev();
            user();
        New://set New point
            GetMinAndMaxNumber(out rMin, out rMax);

            //random
            //GetRandomNumber(rMin,rMax);
            Random random = new Random();
            int correct = random.Next(rMin, rMax);
            //print number
            PrintNumber(rMin, rMax);
            //check guess number
            while (guess != correct)
            {
                //input number                
                var tmp = getGuess(Console.ReadLine());
                if (tmp.HasValue)
                {
                    guess = tmp.Value;

                    if (guess > rMax || guess < rMin)
                    {
                        Console.WriteLine($"{Environment.NewLine}this number not in range");
                    }
                    else if (guess < correct)
                    {
                        ColorMes(ConsoleColor.White, $"{guess} is lower");
                    }
                    else if (guess > correct)
                    {
                        ColorMes(ConsoleColor.White, $"{guess} is higher");
                    }
                    else
                    {
                        /// กรณีคำตอบถูกต้อง                        
                        ColorMes(ConsoleColor.Green, $"CORRECT{Environment.NewLine}");
                        do
                        {
                            AskContinue(correct);
                            rMax = 0;
                            rMin = 0;
                            goto New;
                        } while (true);
                    }
                    // เล่นต่ออีกไหม?
                    AskContinue(correct);
                }
            }
        }
        static void dev()
        {
            Console.WriteLine($"Guessing Number game V.1.0.0{Environment.NewLine}by Boss{Environment.NewLine}===========================");
        }
        static void user()
        {
            Console.WriteLine("What your name?");
            string playerName = Console.ReadLine();
            Console.WriteLine($"{Environment.NewLine}Hello {playerName}{Environment.NewLine}");

        }
        static int? getGuess(string input)
        {
            int? result = null;
            var tmp = 0;
            //valid string to int
            if (!int.TryParse(input, out tmp))
            {
                ColorMes(ConsoleColor.White, "please enter number");
            }
            else
            {
                result = tmp;
            }
            return result;
        }
        static int checkNumber(string input, string word)
        {
            var rMin = 0;
            while (!int.TryParse(input, out rMin))
            {
                Console.WriteLine("Please Enter a valid numerical value!");
                Console.Write($"{word} range is:");
            }

            return rMin;
        }
        static void AskContinue(int correct)
        {
            do
            {
                int k = 1;
                var answer = string.Empty; // ""
                Console.WriteLine("play again y/n (Y)");

            answ:
                answer = Console.ReadLine().ToUpper();
                if (answer == "Y" || string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine($"{Environment.NewLine}Enter number");
                    //Console.Clear();    
                    break;
                }
                else if (answer == "N")
                {

                    Console.WriteLine($"{Environment.NewLine}Correct number is {correct}");
                    Console.WriteLine("Press enter to exit");
                    Console.ReadKey();
                    
                    return ;
                }
                else
                {
                    Console.WriteLine("Please enter Y or N"); ;
                    goto answ;
                }

            } while (true);
        }
        static void GetMinAndMaxNumber(out int rMin, out int rMax)
        {
            Console.Write("Minimum range is:");

            //check number min
            rMin = checkNumber(Console.ReadLine(), "Minimum");
        Max://set Max point
            Console.Write("Maximum range is:");
            //check number max
            rMax = checkNumber(Console.ReadLine(), "Maximum");


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
            Console.WriteLine($"Guess the number");
        }
        private static int GetRandomNumber(int rMin, int rMax)
        {

            Random random = new Random();
            int correct = random.Next(rMin, rMax);
            return correct;
        }
    }
}

//    var answerwin = string.Empty;
//    Console.WriteLine("play again y/n (Y)");
//answ:
//    answerwin = Console.ReadLine().ToUpper();
//    if (answerwin == "Y" || string.IsNullOrEmpty(answerwin))
//    {
//        Console.Clear();
//        rMax = 0;
//        rMin = 0;
//        goto New;
//    }
//    else if (answerwin == "N")
//    {
//        return;
//    }
//    else
//    {
//        Console.WriteLine("Please enter Y or N"); ;
//        goto answ;
//    }