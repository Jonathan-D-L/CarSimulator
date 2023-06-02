using ServiceLibrary.Models;
using UtilityLibrary;

namespace ServiceLibrary
{
    public class PromptService : IPromptService
    {
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
        public string GetGameTitle()
        {
            return "    _____ _____ _____    _____ _____ _____ _____ __    _____ _____ _____ _____      ______" +
                   "\r\n   |     |  _  | __  |  |   __|     |     |  |  |  |  |  _  |_   _|     | __  |    /|_||_\\`.__" +
                   "\r\n   |   --|     |    -|  |__   |-   -| | | |  |  |  |__|     | | | |  |  |    -|   (   _    _ _\\" +
                   "\r\n   |_____|__|__|__|__|  |_____|_____|_|_|_|_____|_____|__|__| |_| |_____|__|__|   =`-(_)--(_)-'\r\n\r\n";
        }
        public string GetStartPrompt()
        {
            return "    Welcome to Car Simulator! Use Arrow keys or WASD to select options.\r\n";
        }
        public string GetOutOfGasWarning()
        {
            return "out of gas please fill up gas.";
        }
        public string GetTirednessWarning(Driver statsDriver)
        {
            switch (statsDriver.Tiredness)
            {
                case >= 100:
                    return "WARNING! You are almost sleep please take a break and rest.";
                case > 80:
                    return "You are very tired please take a break and rest.";
                case > 60:
                    return "You are starting to get tired maybe take a break and rest";
            }
            return string.Empty;
        }
        public List<string> GetCompass(Car statsCar)
        {
            var compass = new List<string>();
            switch (statsCar.CurrentDirection)
            {
                case CurrentDirection.North:
                    compass.Add("    N");
                    compass.Add("    |");
                    compass.Add("W --+-- E");
                    compass.Add("    |");
                    compass.Add("    S");
                    break;
                case CurrentDirection.West:
                    compass.Add("    W");
                    compass.Add("    |");
                    compass.Add("S --+-- N");
                    compass.Add("    |");
                    compass.Add("    E");
                    break;
                case CurrentDirection.South:
                    compass.Add("    S");
                    compass.Add("    |");
                    compass.Add("E --+-- W");
                    compass.Add("    |");
                    compass.Add("    N");
                    break;
                case CurrentDirection.East:
                    compass.Add("    E");
                    compass.Add("    |");
                    compass.Add("N --+-- S");
                    compass.Add("    |");
                    compass.Add("    W");
                    break;
            }
            return compass;
        }
        public string GetCurrentStats(Car statsCar, Driver statsDriver)
        {
            var fuel = "       ";
            var tiredness = "       ";
            var hunger = "";
            var hungerString = "";
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
                hunger = "       ░░░░░░░░░░░░░░░░░░░░░░░░";
            }
            else if (statsDriver.Hunger <= Hunger.Hungry)
            {
                hungerString = nameof(Hunger.Hungry);

                hunger = "       ████████████░░░░░░░░░░░░";
            }
            else if (statsDriver.Hunger >= Hunger.Starving)
            {
                hungerString = nameof(Hunger.Starving);
                hunger = "       ████████████████████████";
            }

            var compass = GetCompass(statsCar);
            var space = TextSpacer.SpaceText(63, statsDriver.Tiredness.ToString());
            return $"\r\n       Direction: {statsCar.CurrentDirection}  " +
                   $"\r\n\r\n       Fuel: {statsCar.Fuel}%\r\n{fuel}                         {compass[0]}" +
                   $"\r\n                                                                                  {compass[1]}" +
                   $"\r\n       Tiredness: {statsDriver.Tiredness}%{space}{compass[2]}\r\n" +
                   $"{tiredness}                         {compass[3]}" +
                   $"\r\n                                                                                  {compass[4]}" +
                   $"\r\n       Hunger: {hungerString}\r\n{hunger}\r\n";
        }

        public string GetLastAction(CarActions carAction, DriverActions driverAction)
        {
            var lastAction = "\r\n";
            var space = string.Empty;
            if (carAction != CarActions.Default)
            {
                switch (carAction)
                {
                    case CarActions.TurnLeft:
                        lastAction = "You turned left.\r\n";
                        break;
                    case CarActions.TurnRight:
                        lastAction = "You turned right.\r\n";
                    
                        break;
                    case CarActions.DriveForwards:
                        lastAction = "You drove forwards.\r\n";
                        break;
                    case CarActions.DriveBackwards:
                        lastAction = "You drove backwards.\r\n";
                        break;
                    case CarActions.Start:
                        lastAction = "You started the car.\r\n";
                        break;
                    case CarActions.Stop:
                        lastAction = "You stopped the car.\r\n";
                        break;
                }
            }
            if (driverAction != DriverActions.Default)
            {
                switch (driverAction)
                {
                    case DriverActions.Drive:
                        lastAction = "You Drove the car\r\n";
                        break;
                    case DriverActions.FillUpGas:
                        lastAction = "You filled the car with gas\r\n";
                        break;
                    case DriverActions.Rest:
                        lastAction = "You took a rest and regained energy\r\n";
                        break;
                    case DriverActions.Eat:
                        lastAction = "You ate some food\r\n";
                        break;
                }
            }
            space = TextSpacer.SpaceText(50, lastAction.Length / 2);
            lastAction = $"\r\n{space}{lastAction}";
            return lastAction;
        }
    }
}
