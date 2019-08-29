using System;

namespace Ex9A_GuessMyNumberGame
{
    public class ComputerPlays
    {
        int lowerLimit;
        int upperLimit;

        public ComputerPlays(int lowerLimit, int upperLimit)
        {
            this.lowerLimit = lowerLimit;
            this.upperLimit = upperLimit;
        }
        public int CPlay()
        {
            Random rand = new Random();

            int target = Choice(lowerLimit, upperLimit);
            int guesses = 0;

            bool winner = false;

            Console.ForegroundColor = ConsoleColor.Yellow;

            while (winner == false)
            {
                int guess = ((lowerLimit + upperLimit) / 2);
                guesses++;

                winner = checkWinner(guess, target, winner);

                Console.WriteLine($"\nThe computer chooses {guess}.");
                if (guess > target && winner == false)
                {
                    
                    Console.WriteLine($"The answer is lower than {guess}.");
                    upperLimit = guess;
                    Console.WriteLine($"Press ENTER and the computer will choose a number between{lowerLimit} and {upperLimit}.\n");
                    Console.ReadLine();
                }
                else if (guess < target && winner == false)
                {
                    Console.WriteLine($"The answer is higher than {guess}.");
                    lowerLimit = guess;
                    Console.WriteLine($"Press ENTER and the computer will choose a number between {lowerLimit} and {upperLimit}.\n");
                    Console.ReadLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{guess} is correct! It took the computer {guesses} guesses!");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }

            return guesses;
        }
        private int Choice(int lowerLimit, int upperLimit)
        {
            bool validChoice = false;
            String ChoicePrompt1 = $"Choose a number between {lowerLimit} and {upperLimit}";
            int choice = 0;

            do
            {
                try
                {
                    Console.WriteLine(ChoicePrompt1);
                    choice = int.Parse(Console.ReadLine());
                    if (choice >= lowerLimit && choice <= upperLimit)
                    {
                        validChoice = true;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEnter a valid integer between ->{lowerLimit} and {upperLimit}<-\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            } while (validChoice == false);
            return choice;
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

