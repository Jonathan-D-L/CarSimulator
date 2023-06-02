using ServiceLibrary;
using ServiceLibrary.Models;
using UtilityLibrary;

namespace CarSimulator
{
    public class CarGame
    {
        private readonly IPromptService _promptService;
        private readonly IActionService _actionService;
        public CarGame(IPromptService promptService, IActionService actionService)
        {
            _promptService = promptService;
            _actionService = actionService;
        }
        public void Game()
        {
            var selector = 0;
                var statsCar = _actionService.GetCarStats();
                var statsDriver = _actionService.GetDriverStats();
                bool resting = false;
                bool filUpGas = false;
                bool eat = false;
            while (true)
            {
                if (statsCar.Fuel <= 0)
                {
                    statsCar.Fuel = 0;
                }
                var options = _promptService.GetGameOptions();
                var stats = _promptService.GetCurrentStatsStrung(statsCar, statsDriver);
                selector = Selector.GetSelections(selector, options, stats);
                switch (selector)
                {
                    case 0:
                        //turn left
                        if (statsCar.Fuel <= 0) { break; }
                        statsDriver.Hunger += 1;
                        statsDriver.Tiredness += 2;
                        statsCar.Fuel -= 1;
                        statsCar.CurrentDirection = _actionService.GetCurrentDirection(statsCar, CarActions.TurnLeft);
                        break;
                    case 1:
                        //turn right
                        if (statsCar.Fuel <= 0) { break; }
                        statsDriver.Hunger += 1;
                        statsDriver.Tiredness += 2;
                        statsCar.Fuel -= 1;
                        statsCar.CurrentDirection = _actionService.GetCurrentDirection(statsCar, CarActions.TurnRight);
                        break;
                    case 2:
                        if (statsCar.Fuel <= 0) { break; }
                        statsDriver.Hunger += 1;
                        statsDriver.Tiredness += 2;
                        statsCar.Fuel -= 5;
                        //drive forwards
                        break;
                    case 3:
                        if (statsCar.Fuel <= 0) { break; }
                        statsDriver.Hunger += 1;
                        statsDriver.Tiredness += 2;
                        statsCar.Fuel -= 2;
                        //reverse
                        break;
                    case 4:
                        //rest
                        resting = true;
                        break;
                    case 5:
                        //fill up gas
                        filUpGas = true;
                        break;
                    case 6:
                        //eat
                        eat = true;
                        break;
                    case 7:
                        //quit
                        return;
                }

                if (resting)
                {
                    statsDriver.Tiredness = 0;
                    resting = false;
                }
                if (filUpGas)
                {
                    statsCar.Fuel = 100;
                    filUpGas = false;
                }
                if (eat)
                {
                    statsDriver.Hunger = 0;
                    eat = false;
                }
            }
        }
    }
}
