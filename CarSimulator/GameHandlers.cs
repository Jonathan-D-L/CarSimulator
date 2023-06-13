using ServiceLibrary;
using ServiceLibrary.Models;
using UtilityLibrary;

namespace CarSimulator
{
    public class GameHandlers
    {
        private readonly IPromptService _promptService;
        private readonly IActionService _actionService;
        public GameHandlers(IPromptService promptService, IActionService actionService)
        {
            _promptService = promptService;
            _actionService = actionService;
        }
        public void HandleHungerWarnings(Driver statsDriver, List<string> warnings)
        {
            switch (statsDriver.Hunger)
            {
                case > Hunger.Full and <= Hunger.Hungry when !warnings.Contains(_promptService.GetHungerWarning(statsDriver)):
                    warnings.Add(_promptService.GetHungerWarning(statsDriver));
                    break;
                case >= Hunger.Starving when !warnings.Contains(_promptService.GetHungerWarning(statsDriver)):
                    warnings.Add(_promptService.GetHungerWarning(statsDriver));
                    break;
            }
        }

        public void HandleGasWarnings(bool outOfGas, List<string> warnings)
        {
            switch (outOfGas)
            {
                case true when !warnings.Any(s => s.Equals(_promptService.GetOutOfGasWarning())):
                    warnings.Add(_promptService.GetOutOfGasWarning());
                    break;
                case false:
                    break;
            }
        }

        public int HandleTiredness(Driver statsDriver, List<string> warnings, int crashThreshold)
        {
            switch (statsDriver.Tiredness)
            {
                case < 60:
                    break;
                case >= 60 and <= 80 when !warnings.Any(s => s.Equals(_promptService.GetTirednessWarning(statsDriver))):
                    crashThreshold = 10;
                    warnings.Add(_promptService.GetTirednessWarning(statsDriver));
                    break;
                case > 80 when !warnings.Any(s => s.Equals(_promptService.GetTirednessWarning(statsDriver))):
                    crashThreshold = 20;
                    warnings.Add(_promptService.GetTirednessWarning(statsDriver));
                    break;
                case 100 when !warnings.Any(s => s.Equals(_promptService.GetTirednessWarning(statsDriver))):
                    crashThreshold = 70;
                    warnings.Add(_promptService.GetTirednessWarning(statsDriver));
                    break;
            }

            return crashThreshold;
        }

        public bool GameOverHandler(int crashThreshold, int selector, Driver statsDriver, Car statsCar, ref int tirednessThreshold)
        {
            var crashed = CarCrashChance.CrashChance(crashThreshold);
            if (crashed && selector < 4 && statsCar.Fuel != 0)
            {
                Console.Clear();
                Console.WriteLine(_promptService.GetGameTitle());
                Console.WriteLine(_promptService.GetGameOverMessage(GameOver.Crashed, statsDriver));
                Thread.Sleep(2000);
                Console.ReadKey();
                return true;
            }

            if (statsDriver.Hunger >= (Hunger)16)
            {
                Console.Clear();
                Console.WriteLine(_promptService.GetGameTitle());
                Console.WriteLine(_promptService.GetGameOverMessage(GameOver.Starved, statsDriver));
                Thread.Sleep(2000);
                Console.ReadKey();
                return true;
            }

            switch (statsDriver.Tiredness)
            {
                case 0:
                    tirednessThreshold = 0;
                    break;
                case 100:
                    tirednessThreshold++;
                    if (tirednessThreshold >= 5)
                    {
                        Console.Clear();
                        Console.WriteLine(_promptService.GetGameTitle());
                        Console.WriteLine(_promptService.GetGameOverMessage(GameOver.Dozed, statsDriver));
                        Thread.Sleep(2000);
                        Console.ReadKey();
                        return true;
                    }

                    break;
            }
            return false;
        }
    }
}
