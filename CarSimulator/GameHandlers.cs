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
                case > Hunger.Starving when !warnings.Contains(_promptService.GetHungerWarning(statsDriver)):
                    warnings.RemoveAll(s => s.Contains(nameof(Hunger.Hungry).ToLower()));
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
                    warnings.RemoveAll(s => s.Equals(_promptService.GetOutOfGasWarning()));
                    break;
            }
        }

        public int HandleTiredness(Driver statsDriver, List<string> warnings, int crashThreshold)
        {
            switch (statsDriver.Tiredness)
            {
                case < 60:
                    warnings.Clear();
                    break;
                case >= 60 and <= 80 when !warnings.Any(s => s.Equals(_promptService.GetTirednessWarning(statsDriver))):
                    warnings.Clear();
                    crashThreshold = 10;
                    warnings.Add(_promptService.GetTirednessWarning(statsDriver));
                    break;
                case > 80 when !warnings.Any(s => s.Equals(_promptService.GetTirednessWarning(statsDriver))):
                    warnings.Clear();
                    crashThreshold = 20;
                    warnings.Add(_promptService.GetTirednessWarning(statsDriver));
                    break;
                case 100 when !warnings.Any(s => s.Equals(_promptService.GetTirednessWarning(statsDriver))):
                    warnings.Clear();
                    crashThreshold = 70;
                    warnings.Add(_promptService.GetTirednessWarning(statsDriver));
                    break;
            }

            return crashThreshold;
        }
    }
}
