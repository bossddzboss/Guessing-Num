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

            dev();
            user();            
            do//Start loop play again
            {
                GetMinAndMaxNumber(out rMin, out rMax);                               
                Random random = new Random(); //random number 
                int correct = random.Next(rMin, rMax);  //random number               
                PrintNumber(rMin, rMax);               
                while (guess != correct)//check guess number
                {                                    
                    var tmp = getGuess(Console.ReadLine());//input number
                    if (tmp.HasValue)//valid input number
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
                        else// when pass  
                        {                                                 
                            ColorMes(ConsoleColor.Green, $"CORRECT{Environment.NewLine}");
                            //do
                            //{
                            //    //TODO: config loop
                            //    bool con  = AskContinue(correct);
                            //    if (con == false) {
                            //        break;
                            //    }
                            //    rMax = 0;
                            //    rMin = 0;
                            //    goto New;
                            //} while (true);
                            bool con2 = AskContinue(correct);//valid char input
                            if (con2 == true)//valid play again
                            {//yes to continue
                                break;
                            }
                            else
                            {//no to exit
                                return;
                            }
                        }
                    }
                }
            } while (true);//End loop play again
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