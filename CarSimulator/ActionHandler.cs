using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary;

namespace CarSimulator
{
    public class ActionHandler
    {
        private readonly ICarActionService _carActionService;

        public ActionHandler(ICarActionService carActionService)
        {
            _carActionService = carActionService;
        }
        public void Action()
        {
            var action = Console.ReadKey().Key;
            switch (action)
            {
                case ConsoleKey.W:

                    break;
                case ConsoleKey.A:
                    break;
                case ConsoleKey.S:
                    break;
                case ConsoleKey.D:
                    break;
                case ConsoleKey.D5:
                    break;
                case ConsoleKey.D6:
                    break;
                default:
                    break;
            }
        }
    }
}
