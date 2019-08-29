using System;

namespace Ex9A_GuessMyNumberGame
{
    public class ListNavigation
    {
        string[] list;
        int cursorStart;
        bool abort;

        public ListNavigation(string[] list, int cursorStart, bool abort)
        {
            this.list = list;
            this.cursorStart = cursorStart;
            this.abort = abort;
        }

        public (bool, int) scrollList()
        {
            abort = false;
            Console.SetCursorPosition(0, cursorStart);

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine($" {list[i]}");
                Console.WriteLine();
            }

            int index = 0;

            Console.SetCursorPosition(0, cursorStart);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write($" {list[index]}");
            Console.ResetColor();
            Console.SetCursorPosition(0, 6);

            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < list.Length - 1)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($" {list[index]}");

                            index++;

                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($" {list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case ConsoleKey.UpArrow:

                        if (index > 0)
                        {
                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($" {list[index]}");

                            index--;

                            Console.SetCursorPosition(0, cursorStart + (2 * index));
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write($" {list[index]}");
                            Console.ResetColor();
                            Console.SetCursorPosition(0, 6);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.Escape:
                        abort = true;
                        break;
                }
            } while (cki.Key != ConsoleKey.Enter && abort != true);
            return (abort, index);
        }
    }
}

