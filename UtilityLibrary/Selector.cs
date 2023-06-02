using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary
{
    public class Selector
    {
        public static int GetSelections(int selector, List<string> options, string prompt, string stats, List<string> warnings)
        {
            while (true)
            {
                var index = 0;
                Console.Clear();
                Console.WriteLine(prompt);
                foreach (var option in options)
                {
                    if (selector == index)
                    {
                        Console.Write($"     > {option}");
                    }
                    else
                    {
                        Console.Write($"       {option}");
                    }

                    if (warnings != null)
                    {
                        var space = TextSpacer.SpaceText(35, option);
                        if (warnings.Count > index)
                        {
                            Console.Write($"{space}{warnings[index]}\r\n");
                        }
                        else
                        {
                            Console.Write($"\r\n");
                        }
                    }

                    index++;
                }
                Console.WriteLine(stats);
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
