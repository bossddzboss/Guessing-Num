using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guessing_Num
{
    class GuessGame
    {
        private int _correct;
        private Random _random;

        public int GuessNum;
        public int Min { get; protected set; }
        public int Max { get; protected set; }

        public GuessGame()
        {
            _random = new Random(); //random number 
        }

        public void SetupGame(string userName,int rMin, int rMax)
        {
            Min = rMin;
            Max = rMax;
            
            _correct = _random.Next(Min, Max);  //random number    
        }
        
        public int GetCorrect()
        {
            return _correct;
        }

        //public int Correct { get { return _correct; } }

        public bool IsCorrect(int guess)
        {
            if (guess > Max || guess < Min)
            {
                throw new GameException($"this number not in range");
            }
            else if (guess < _correct)
            {
                throw new GameException($"{guess} is lower");
            }
            else if (guess > _correct)
            {
                throw new GameException($"{guess} is higher");
            }

            return _correct == guess;
        }

    }

    public class GameException : System.Exception
    {
        public GameException(string message): base(message) { }
    }
}
