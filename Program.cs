using System;
using System.Collections.Generic;

namespace GuesserLab
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goOn = true;
            while (goOn == true)
            {
                Random random = new Random();
                int tries = 0;
                int min = 1;
                int max = 100;
                int randomNumber = random.Next(min, max + 1);

                //Print random number to make testing easier
                //Console.WriteLine(randomNumber);

                string response = "";

                while (response != "You guessed it!")
                {
                    int userNum = GetUserInput();
                    response = GetNumberRange(userNum, randomNumber);
                    Console.WriteLine(response);
                    Console.WriteLine();
                    tries++;
                }
                Console.WriteLine($"It took you {tries} tries to guess {randomNumber}");

                Console.WriteLine();
                int i = 1;
                response = "";
                while (response != "You guessed it!")
                {
                    response = GetNumberRange(i, randomNumber);
                    if (response != "You guessed it!")
                    {
                        i++;
                    }
                }
                Console.WriteLine($"The Linear Guesser took {i} times to guess the number {randomNumber}.");
                Console.WriteLine("This version guesses starting at one and ticks up to 100.\n");
                Console.WriteLine($"{BruteForceGuess(randomNumber)}.");
                Console.WriteLine("This version guesses starting at 100 and ticks down to 1.\n");
                Console.WriteLine($"{RandomGuessAlg(randomNumber)}.");
                Console.WriteLine("This version guesses a random number between 1 and 100 everytime. \n");
                Console.WriteLine($"{EliminationGuess(randomNumber)}.");
                Console.WriteLine("This version guesses a random number.  If that number is incorrect, it will not guess it again, but will guess another random number.\n");

                goOn = GuessAgain();
            }
        }

        public static int GetUserInput()
        {
            while (true)
            {
                Console.WriteLine("Please guess a number between 1 and 100.");
                try
                {
                    int num = int.Parse(Console.ReadLine());
                    if (num < 1)
                    {
                        throw new Exception("That number is too small, please input a number between 1 and 100.");
                    }
                    else if (num > 100)
                    {
                        throw new Exception("That number is too large, please inptu a number between 1 and 100.");
                    }
                    return num;

                }
                catch (FormatException)
                {
                    Console.WriteLine("That was not a valid number please try again.");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        public static string GetNumberRange(int userNum, int randomNumber)
        {
            if (userNum == randomNumber)
            {
                return "You guessed it!";
            }
            int diff = userNum - randomNumber;
            diff = Math.Abs(diff);

            if (userNum > randomNumber)
            {
                if (diff > 10)
                {
                    return "Way too high!";
                }
                else
                {
                    return "Too high!";
                }
            }
            else
            {
                if (diff > 10)
                {
                    return "Way too low!";
                }
                else
                {
                    return "Too low!";
                }
            }

        }

        public static string RandomGuessAlg(int randomNum)
        {
            Random random = new Random();
            int compRandom = random.Next(1, 101);
            int tries = 0;
            while (compRandom != randomNum)
            {
                compRandom = random.Next(1, 101);
                tries++;
            }

            return $"The Random Number Guesser took {tries} times to guess the number {randomNum} ";
        }

        public static string EliminationGuess(int randomNum)
        {
            Random random = new Random();
            List<int> guesses = new List<int>();
            int compGuess = random.Next(1, 101);
            int tries = 0;
            do
            {
                compGuess = random.Next(1, 101);
                if (!guesses.Contains(compGuess))
                {
                    guesses.Add(compGuess);
                    tries++;
                }
            }
            while (compGuess != randomNum);

            return $"The Elimination Guesser took {tries} times to guess the number {randomNum} ";
        }

        public static string BruteForceGuess(int randomNum)
        {
            int tries = 0;
            int i = 100;
            while (i != randomNum)
            {
                i--;
                tries++;
            }
            return $"The Brute Force Guesser took {tries} times to guess the number {randomNum} ";
        }
        public static bool GuessAgain()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to play again? y/n");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y")
            {
                return true;
            }
            else if (answer.ToLower() == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand your response, please try again...");
            }
            return GuessAgain();
        }
    }
}
