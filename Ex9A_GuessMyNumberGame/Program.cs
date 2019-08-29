using System.Collections.Generic;
using System;

namespace Ex9A_GuessMyNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            new App().Run();
        }
    }

    class App
    {
        public void Run()

        {
            string[] choices = { "Computer Picks Number, Human Guesses", "Human Picks Number, Computer Guesses" };
            bool finished = false;

            int compGuesses = 0;
            int compGames = 0;
            int humanGuesses = 0;
            int humanGames = 0;
            int selected = 0;

            ListNavigation listNav = new ListNavigation(choices, 6, finished);
            UI ui = new UI();

            while (finished != true)
            {
                Console.Clear();
                ui.printUI(compGuesses, compGames, humanGuesses, humanGames);
                (finished, selected) = listNav.scrollList();
                Console.Clear();
                if (selected == 0)
                {
                    humanGuesses += new HumanPlays(0, 1000).HPlay();      //// Sets upper and lower limits for guessing
                    humanGames++;
                }
                else
                {
                    compGuesses += new ComputerPlays(0, 1000).CPlay();   //// Sets upper and lower limits for guessing
                    compGames++;

                }
                
            }
        }
    }

    public class UI
    {
        
       public void printUI(int compGuesses, int compGames, int humanGuesses, int humanGames)
        {
            double compAve = 0;
            double humanAve = 0;

            if (compGames > 0)
            {
                compAve = compGuesses / compGames;
            }
            
            if (humanGames > 0)
            {
                humanAve = humanGuesses / humanGames;
            }

            string computerStats = $"Computer:\tGames ({compGames})\tGuesses ({compGuesses})\tAverage ({compAve})";
            string humanStats = $"Human:\t\tGames ({humanGames})\tGuesses ({humanGuesses})\tAverage ({humanAve})";

            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"{computerStats}");
            Console.WriteLine($"{humanStats}");
        }
    }
}

