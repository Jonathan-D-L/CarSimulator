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

        public string GetGameOverMessage(GameOver gameOverReason, Driver statsDriver)
        {
            var gameOver = "                    __     __    _      ____      ___   _      ____  ___  \r\n" +
                           "                   / /`_  / /\\  | |\\/| | |_      / / \\ \\ \\  / | |_  | |_) \r\n" +
                           "                   \\_\\_/ /_/--\\ |_|  | |_|__     \\_\\_/  \\_\\/  |_|__ |_| \\";

            switch (gameOverReason)
            {
                case GameOver.Crashed:
                    var gameOverString = $"{statsDriver.GivenName} {statsDriver.SurName} Crashed due to being tired. Press any key to continue...";
                    var space = TextSpacer.SpaceText(45, gameOverString.Length / 2);
                    return $"{gameOver}\r\n\r\n\r\n{space}{gameOverString}";
                case GameOver.Starved:
                    gameOverString = $"{statsDriver.GivenName} {statsDriver.SurName} Starved to death. Press any key to continue...";
                    space = TextSpacer.SpaceText(45, gameOverString.Length / 2);
                    return $"{gameOver}\r\n\r\n\r\n{space}{gameOverString}";
                case GameOver.FellAsleep:
                    gameOverString = $"{statsDriver.GivenName} {statsDriver.SurName} Fell asleep. Press any key to continue...";
                    space = TextSpacer.SpaceText(45, gameOverString.Length / 2);
                    return $"{gameOver}\r\n\r\n\r\n{space}{gameOverString}";
            }

            return string.Empty;
        }
        public string GetStartPrompt()
        {
            return "    Welcome to Car Simulator! Use Arrow keys or WASD to select options.\r\n";
        }
        public string GetOutOfGasWarning()
        {
            return "The car is out of gas please fill up on gas to continue driving.";
        }
        public string GetHungerWarning(Driver statsDriver)
        {
            var hungerWarning = string.Empty;
            switch (statsDriver.Hunger)
            {
                case > Hunger.Full and <= Hunger.Hungry:
                    hungerWarning = $"{statsDriver.GivenName} is hungry and should eat something!";
                    break;
                case > Hunger.Starving:
                    hungerWarning = $"WARNING! {statsDriver.GivenName} is starving and needs to eat something!";
                    break;
            }

            return hungerWarning;
        }
        public string GetTirednessWarning(Driver statsDriver)
        {
            switch (statsDriver.Tiredness)
            {
                case >= 100:
                    return $"WARNING! {statsDriver.GivenName} is almost asleep and needs to take a break!";
                case > 80:
                    return $"{statsDriver.GivenName} is very tired and needs to take a break.";
                case > 60:
                    return $"{statsDriver.GivenName} is starting to get tired, maybe take a break.";
            }
            return string.Empty;
        }
        public List<string> GetCompass(Car statsCar)
        {
            var compass = new List<string>();
            switch (statsCar.CurrentDirection)
            {
                case CurrentDirection.North:
                    compass.Add(" [Direction]");
                    compass.Add(" ___________");
                    compass.Add("/     N     \\");
                    compass.Add("█     ↑     █");
                    compass.Add("█ W --+-- E █");
                    compass.Add("█     |     █");
                    compass.Add("\\_____S_____/");
                    break;
                case CurrentDirection.West:
                    compass.Add(" [Direction]");
                    compass.Add(" ___________");
                    compass.Add("/     W     \\");
                    compass.Add("█     ↑     █");
                    compass.Add("█ S --+-- N █");
                    compass.Add("█     |     █");
                    compass.Add("\\_____E_____/");
                    break;
                case CurrentDirection.South:
                    compass.Add(" [Direction]");
                    compass.Add(" ___________");
                    compass.Add("/     S     \\");
                    compass.Add("█     ↑     █");
                    compass.Add("█ E --+-- W █");
                    compass.Add("█     |     █");
                    compass.Add("\\_____N_____/");
                    break;
                case CurrentDirection.East:
                    compass.Add(" [Direction]");
                    compass.Add(" ___________ ");
                    compass.Add("/     E     \\");
                    compass.Add("█     ↑     █");
                    compass.Add("█ N --+-- S █");
                    compass.Add("█     |     █");
                    compass.Add("\\_____W_____/");
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
                hunger = "       ████████████████████████";
            }
            else if (statsDriver.Hunger <= Hunger.Hungry)
            {
                hungerString = nameof(Hunger.Hungry);

                hunger = "       ████████████░░░░░░░░░░░░";
            }
            else if (statsDriver.Hunger >= Hunger.Starving)
            {
                hungerString = nameof(Hunger.Starving);
                hunger = "       ░░░░░░░░░░░░░░░░░░░░░░░░";
            }

            var compass = GetCompass(statsCar);
            var space = TextSpacer.SpaceText(63, statsDriver.Tiredness.ToString());
            var space2 = TextSpacer.SpaceText(68, statsCar.Fuel.ToString());
            var space3 = TextSpacer.SpaceText(67, hungerString);
            return $"\r\n       ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ STATS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                   $"\r\n" +
                   $"\r\n       Fuel: {statsCar.Fuel}%{space2}{compass[0]}" +
                   $"\r\n{fuel}                         {compass[1]}" +
                   $"\r\n                                                                                  {compass[2]}" +
                   $"\r\n       Tiredness: {statsDriver.Tiredness}%{space}{compass[3]}\r\n" +
                   $"{tiredness}                         {compass[4]}" +
                   $"\r\n                                                                                  {compass[5]}" +
                   $"\r\n       Hunger: {hungerString}{space3}{compass[6]}" +
                   $"\r\n{hunger}";
        }

        public string GetLastAction(CarActions carAction, DriverActions driverAction, Driver statsDriver)
        {
            var lastAction = "\r\n";
            var space = string.Empty;
            if (carAction != CarActions.Default)
            {
                switch (carAction)
                {
                    case CarActions.TurnLeft:
                        lastAction = $"{statsDriver.GivenName} turned left.\r\n";
                        break;
                    case CarActions.TurnRight:
                        lastAction = $"{statsDriver.GivenName} turned right.\r\n";
                        break;
                    case CarActions.DriveForward:
                        lastAction = $"{statsDriver.GivenName} drove forwards.\r\n";
                        break;
                    case CarActions.DriveBackward:
                        lastAction = $"{statsDriver.GivenName} drove backwards.\r\n";
                        break;
                    case CarActions.Start:
                        lastAction = $"{statsDriver.GivenName} started the car.\r\n";
                        break;
                    case CarActions.Stop:
                        lastAction = $"{statsDriver.GivenName} stopped the car.\r\n";
                        break;
                    case CarActions.FillUpGas:
                        lastAction = "The gas tank is already full.\r\n";
                        break;
                }
            }
            if (driverAction != DriverActions.Default)
            {
                switch (driverAction)
                {
                    case DriverActions.Drive:
                        lastAction = $"{statsDriver.GivenName} is driving the car.\r\n";
                        break;
                    case DriverActions.FillUpGas:
                        lastAction = $"{statsDriver.GivenName} filled up the car with gas.\r\n";
                        break;
                    case DriverActions.Rest:
                        lastAction = $"{statsDriver.GivenName} took a break and regained some energy.\r\n";
                        break;
                    case DriverActions.Eat:
                        lastAction = $"{statsDriver.GivenName} consumed some food and is now full and satisfied.\r\n";
                        break;
                }
            }
            space = TextSpacer.SpaceText(50, lastAction.Length / 2);
            lastAction = $"\r\n{space}{lastAction}";
            return lastAction;
        }
    }
}
