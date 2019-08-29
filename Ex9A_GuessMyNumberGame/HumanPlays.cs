using System;

namespace Ex9A_GuessMyNumberGame
{
    public class HumanPlays
    {
        int lowerLimit;
        int upperLimit;

        public HumanPlays(int lowerLimit, int upperLimit)
        {
            this.lowerLimit = lowerLimit;
            this.upperLimit = upperLimit;
        }
        public int HPlay()
        {
            Random rand = new Random();

            int target = rand.Next(lowerLimit, upperLimit + 1);
            int guesses = 0;
            int guess;
            int newLower = lowerLimit;
            int newUpper = upperLimit;

            bool winner = false;

            Console.ForegroundColor = ConsoleColor.Yellow;

            while (winner == false)
            {
                guess = Guess(newLower, newUpper);
                guesses++;

                winner = checkWinner(guess, target, winner);

                if (guess > target && winner == false)
                {
                    Console.WriteLine($"\nThe answer is lower than {guess}\n");
                    newUpper = guess;
                }
                else if (guess < target && winner == false)
                {
                    Console.WriteLine($"\nThe answer is higher than {guess}\n");
                    newLower = guess;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{guess} is correct! It only took {guesses} guesses!");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            return guesses;
        }

        private int Guess(int thisLowerLimit, int thisUpperLimit)
        {

            bool validGuess = false;
            int guess = 0;

            while(validGuess == false)
            {
                String GuessPrompt1 = $"Guess a number between {thisLowerLimit} and {thisUpperLimit}";

                Console.WriteLine($"{GuessPrompt1}");

                var line = Console.ReadLine();

                try
                {
                    guess = int.Parse(line);

                    if (guess >= thisLowerLimit && guess <= thisUpperLimit)
                    {
                        validGuess = true;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nInput Invalid\n{e}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                
            } ;
            return guess;
        }

        public bool checkWinner(int guess, int target, bool winner)
        {
            if (guess == target)
            {
                winner = true;
            }

            return winner;
        }
    }
}

