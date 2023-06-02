using ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        List<string> GetCompass(Car statsCar);
        string GetLastAction(CarActions carAction, DriverActions driverAction);
        string GetHungerWarning(Driver statsDriver);
    }
}
