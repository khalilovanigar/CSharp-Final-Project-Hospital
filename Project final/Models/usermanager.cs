namespace MenuHelperNamespace
{
    using System;
    using System.Collections.Generic;

    public static class MenuHelper
    {
        public static int SelectFromMenu(List<string> options, string title)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine($"--- {title} ---");
                 System.Console.WriteLine();
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }

                var keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

                if (key == ConsoleKey.UpArrow && selectedIndex > 0)
                    selectedIndex--;
                else if (key == ConsoleKey.DownArrow && selectedIndex < options.Count - 1)
                    selectedIndex++;

            } while (key != ConsoleKey.Enter);

            return selectedIndex;
        }
    }
}

