using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models;
using UtilityLibrary;

namespace ServiceLibrary
{
    public class PromptService : IPromptService
    {
        public string GetActionPrompt(CarActions carAction, DriverActions driverAction)
        {
            return null;
        }

        public List<string> GetStartOptions()
        {
            return new List<string>
            {
                "Play",
                "Quit"
            };
        }
        public List<string> GetGameOptions()
        {
            return new List<string>
            {
                "Turn Left",
                "Turn Right",
                "Drive Forwards",
                "Reverse",
                "Rest",
                "FillUpGas",
                "Eat",
                "Quit"
            };
        }
        public string GetStartPrompt()
        {
            return "  Welcome to Car Simulator!\r\n     ______\r\n    /|_||_\\`.__\r\n   (   _    _ _\\\r\n   =`-(_)--(_)-'\r\n  Use Arrow keys or WASD to select options:\r\n";
        }

        public string GetOutOfGasPrompt()
        {
            return "out of gas please fill up gas";
        }

        public string GetCurrentStatsStrung(Car statsCar, Driver statsDriver)
        {
            var fuel = "";
            var hunger = "";
            var hungerString = "";
            var tiredness = "";
            for (int i = 0; i < 50; i++)
            {
                if (i < statsCar.Fuel / 2)
                {
                    fuel += "█";
                }
                else
                {
                    fuel += "░";
                }
            }
            for (int i = 0; i < 50; i++)
            {
                if (i < statsDriver.Tiredness / 2)
                {
                    tiredness += "█";
                }
                else
                {
                    tiredness += "░";
                }
            }
            if (statsDriver.Hunger <= Hunger.Full)
            {
                hungerString = nameof(Hunger.Full);
                hunger = "░░░░░░░░░░░░░░░░░░░░░░░░";
            }
            else if (statsDriver.Hunger <= Hunger.Hungry)
            {
                hungerString = nameof(Hunger.Hungry);

                hunger = "████████████░░░░░░░░░░░░";
            }
            else if (statsDriver.Hunger >= Hunger.Starving)
            {
                hungerString = nameof(Hunger.Starving);
                hunger = "████████████████████████";
            }
            return $"Direction: {statsCar.CurrentDirection}\r\nFuel:{statsCar.Fuel}%\r\n{fuel}\r\nTiredness:\r\n{tiredness}\r\nHunger: {hungerString}\r\n{hunger}";
        }
    }
}
