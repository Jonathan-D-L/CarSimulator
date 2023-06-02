using ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public interface IPromptService
    {
        List<string> GetStartOptions();
        List<string> GetGameOptions();
        string GetStartPrompt();
        string GetCurrentStatsStrung(Car statsCar, Driver statsDriver);
        string GetOutOfGasPrompt();
    }
}
