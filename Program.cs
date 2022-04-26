using System;
using System.Collections.Generic;

namespace CSharp.LabExercise6
{
    class Scrabble
    {
        public int TotalScore { get; set; }

        public static Dictionary<char, int> letters = new Dictionary<char, int>()
        {

        {'A',1},{'B',3},{'C',3},
        {'D',2},{'E',1},{'F',4},
        {'G',2}, {'H',4}, {'I',1},
        {'J',8}, {'K',5},{'L',1},
        {'M',3}, {'N',1}, {'O',1},
        {'P',3}, {'Q',10},{'R',1},
        {'S',1}, {'T',1}, {'U',1},
        {'V',5}, {'W',4},{'X',8},
        {'Y',4}, {'Z', 10} 
        };

        public int wordScore(string input)
        {
            TotalScore = 0;
            int point;
            foreach(char c in input)
            {
                letters.TryGetValue(c, out point);
                TotalScore += point;
            }
            return TotalScore;
        }
    }
    
    class InputValidator
    {
        public bool validator(string input)
        {
            if(!input.Trim().Equals(""))
            {
                if(validInputs(input))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool validInputs(string input)
        {
            string validChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < input.Length; i++)
            {
                if (!validChar.Contains(input[i])) return false;
            }

            return true;
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            string again = "y";
            while(again == "y")
            {
                Console.Write("Enter a word:");
                string wordInput = Console.ReadLine();
                Scrabble scrabble = new Scrabble();
                InputValidator validator = new InputValidator();
                bool isValid = validator.validator(wordInput.ToUpper());
                if (isValid)
                {
                    Console.WriteLine($"Total Score: {scrabble.wordScore(wordInput.ToUpper())}");
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                    Console.WriteLine("Word should not contain any special character or number.");
                }
                Console.Write("Try again? (y/n) ");
                again = Console.ReadLine().ToLower();
            }
            
        }
    }
}
