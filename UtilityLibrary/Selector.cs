using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary
{
    public class Selector
    {
        public static int GetSelections(int selector, List<string> options, string prompt)
        {
            while (true)
            {
                Console.Clear();
                var index = 0;
                Console.WriteLine(prompt);
                foreach (var option in options)
                {
                    if (selector == index)
                    {
                        Console.WriteLine($"> {option}");
                    }
                    else
                    {
                        Console.WriteLine($"  {option}");
                    }
                    index++;
                }

                var input = Console.ReadKey().Key;
                if (input == ConsoleKey.Spacebar || input == ConsoleKey.Enter)
                {
                    break;
                }
                if ((input == ConsoleKey.W || input == ConsoleKey.UpArrow) && selector != 0)
                {
                    selector--;
                }
                if ((input == ConsoleKey.S || input == ConsoleKey.DownArrow) && selector != options.Count - 1)
                {
                    selector++;
                }

            }
            return selector;
        }
    }
}
