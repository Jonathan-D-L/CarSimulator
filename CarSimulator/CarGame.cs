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
            var crashThreshold = 0;
            var warnings = new List<string>();
            var statsCar = _actionService.GetCarStats();
            var statsDriver = _actionService.GetDriverStats();
            var outOfGas = false;
            var lastCarAction = CarActions.Default;
            var lastDriverAction = DriverActions.Default;
            while (true)
            {
                var crashed = CarCrashChance.CrashChance(crashThreshold);
                if ((crashed && selector < 4) || statsDriver.Hunger >= (Hunger)16)
                {
                    //game over
                }

                var prompt = _promptService.GetGameTitle();
                prompt += _promptService.GetLastAction(lastCarAction, lastDriverAction);
                lastCarAction = CarActions.Default;
                lastDriverAction = DriverActions.Default;

                if ((statsDriver.Tiredness > 60 && statsDriver.Tiredness < 80) && !warnings.Any(s => s.Equals(_promptService.GetTirednessWarning(statsDriver))))
                {
                    warnings.Clear();
                    crashThreshold = 10;
                    warnings.Add(_promptService.GetTirednessWarning(statsDriver));
                }
                else if ((statsDriver.Tiredness > 80) && !warnings.Any(s => s.Equals(_promptService.GetTirednessWarning(statsDriver))))
                {
                    warnings.Clear();
                    crashThreshold = 20;
                    warnings.Add(_promptService.GetTirednessWarning(statsDriver));
                }
                else if ((statsDriver.Tiredness == 100) && !warnings.Any(s => s.Equals(_promptService.GetTirednessWarning(statsDriver))))
                {
                    warnings.Clear();
                    crashThreshold = 70;
                    warnings.Add(_promptService.GetTirednessWarning(statsDriver));
                }

                if (outOfGas && !warnings.Any(s => s.Equals(_promptService.GetOutOfGasWarning())))
                {
                    warnings.Add(_promptService.GetOutOfGasWarning());
                }
                else if (!outOfGas)
                {
                    warnings.RemoveAll(s => s.Equals(_promptService.GetOutOfGasWarning()));
                }

                if (statsDriver.Hunger > Hunger.Full && statsDriver.Hunger <= Hunger.Hungry && !warnings.Contains(_promptService.GetHungerWarning(statsDriver)))
                {
                    warnings.Add(_promptService.GetHungerWarning(statsDriver));
                }
                else if (statsDriver.Hunger > Hunger.Starving && !warnings.Contains(_promptService.GetHungerWarning(statsDriver)))
                {

                    warnings.RemoveAll(s => s.Contains(nameof(Hunger.Hungry).ToLower()));
                    warnings.Add(_promptService.GetHungerWarning(statsDriver));

                }

                var options = _promptService.GetGameOptions();
                var stats = _promptService.GetCurrentStats(statsCar, statsDriver);
                selector = Selector.GetSelections(selector, options, prompt, stats, warnings);
                switch (selector)
                {
                    case 0:
                        //turn left
                        statsCar = _actionService.SetCarStats(statsCar, CarActions.TurnLeft);
                        lastCarAction = CarActions.TurnLeft;
                        if (statsCar.Fuel == 0) { outOfGas = true; break; }
                        statsCar.CurrentDirection = _actionService.GetCurrentDirection(statsCar, CarActions.TurnLeft);
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Drive);
                        break;
                    case 1:
                        //turn right
                        statsCar = _actionService.SetCarStats(statsCar, CarActions.TurnRight);
                        lastCarAction = CarActions.TurnRight;
                        if (statsCar.Fuel == 0) { outOfGas = true; break; }
                        statsCar.CurrentDirection = _actionService.GetCurrentDirection(statsCar, CarActions.TurnRight);
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Drive);
                        break;
                    case 2:
                        //drive forwards
                        statsCar = _actionService.SetCarStats(statsCar, CarActions.DriveForwards);
                        lastCarAction = CarActions.DriveForwards;
                        if (statsCar.Fuel == 0) { outOfGas = true; break; }
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Drive);
                        break;
                    case 3:
                        //reverse
                        statsCar = _actionService.SetCarStats(statsCar, CarActions.DriveBackwards);
                        lastCarAction = CarActions.DriveBackwards;
                        if (statsCar.Fuel == 0) { outOfGas = true; break; }
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Drive);
                        break;
                    case 4:
                        //rest
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Rest);
                        lastDriverAction = DriverActions.Rest;
                        crashThreshold = 0;
                        break;
                    case 5:
                        //fill up gas
                        statsCar = _actionService.SetCarStats(statsCar, CarActions.FillUpGas);
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.FillUpGas);
                        lastDriverAction = DriverActions.FillUpGas;
                        outOfGas = false;
                        break;
                    case 6:
                        //eat
                        statsDriver = _actionService.SetDriverStats(statsDriver, DriverActions.Eat);
                        lastDriverAction = DriverActions.Eat;
                        break;
                    case 7:
                        //quit
                        return;
                }
            }
        }
    }
}
