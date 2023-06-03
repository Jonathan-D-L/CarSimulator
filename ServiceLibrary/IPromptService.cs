using ServiceLibrary.Models;
using UtilityLibrary;

namespace ServiceLibrary
{
    public interface IPromptService
    {
        List<string> GetStartOptions();
        List<string> GetGameOptions();
        string GetStartPrompt();
        string GetCurrentStats(Car statsCar, Driver statsDriver);
        string GetOutOfGasWarning();
        string GetGameTitle();
        string GetTirednessWarning(Driver statsDriver);
        string GetLastAction(CarActions carAction, DriverActions driverAction, Driver statsDriver);
        string GetHungerWarning(Driver statsDriver);
        string GetGameOverMessage(GameOver gameOverReason, Driver statsDriver);
    }
}
