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
            bool outOfGas = false;
            var prompt = "";
            while (true)
            {
                var options = _promptService.GetGameOptions();
                var stats = _promptService.GetCurrentStatsStrung(statsCar, statsDriver);
                selector = Selector.GetSelections(selector, options, prompt, stats);
                switch (selector)
                {
                    case 0:
                        //turn left
                        statsCar = _actionService.SetCarStats(statsCar, CarActions.TurnLeft);
                        if (statsCar.Fuel == 0) { outOfGas = true; break; }
                        statsCar.CurrentDirection = _actionService.GetCurrentDirection(statsCar, CarActions.TurnLeft);
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Drive);
                        break;
                    case 1:
                        //turn right
                        statsCar = _actionService.SetCarStats(statsCar, CarActions.TurnRight);
                        if (statsCar.Fuel == 0) { outOfGas = true; break; }
                        statsCar.CurrentDirection = _actionService.GetCurrentDirection(statsCar, CarActions.TurnRight);
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Drive);
                        break;
                    case 2:
                        //drive forwards
                        statsCar = _actionService.SetCarStats(statsCar, CarActions.DriveForwards);
                        if (statsCar.Fuel == 0) { outOfGas = true; break; }
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Drive);
                        break;
                    case 3:
                        //reverse
                        statsCar = _actionService.SetCarStats(statsCar, CarActions.DriveBackwards);
                        if (statsCar.Fuel == 0) { outOfGas = true; break; }
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Drive);
                        break;
                    case 4:
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Rest);
                        break;
                    case 5:
                        //fill up gas
                        statsCar = _actionService.SetCarStats(statsCar, CarActions.FillUpGas);
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.FillUpGas);
                        break;
                    case 6:
                        //eat
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Eat);
                        break;
                    case 7:
                        //quit
                        return;
                }

                if (outOfGas)
                {
                    prompt = _promptService.GetOutOfGasPrompt();
                }

                switch (statsDriver.Tiredness)
                {
                    case >= 100:
                        prompt = "service tired fell asleep depending on action game crash roll for crash or car is stopped fell asleep game over";
                        break;
                    case > 80:
                        prompt = "service tired severe";
                        break;
                    case > 60:
                        prompt = "service tired warning";
                        break;
                }
            }
        }
    }
}
