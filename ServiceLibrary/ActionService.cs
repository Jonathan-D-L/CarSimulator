using ServiceLibrary.Models;
using UtilityLibrary;

namespace ServiceLibrary
{
    public class ActionService : IActionService
    {
        public Car GetCarStats()
        {
            return new Car
            {
                Fuel = 100,
                CurrentDirection = CurrentDirection.North
            };
        }
        public Driver GetDriverStats()
        {
            return new Driver
            {
                GivenName = "Jon",
                SurName = "Doe",
                Tiredness = 0,
                Hunger = 0
            };
        }
        public CurrentDirection GetCurrentDirection(Car statsCar, CarActions carActions)
        {
            if (statsCar.CurrentDirection == CurrentDirection.North)
            {
                switch (carActions)
                {
                    case CarActions.TurnLeft:
                        return statsCar.CurrentDirection = CurrentDirection.West;
                    case CarActions.TurnRight:
                        return statsCar.CurrentDirection = CurrentDirection.East;
                }
            }
            if (statsCar.CurrentDirection == CurrentDirection.West)
            {
                switch (carActions)
                {
                    case CarActions.TurnLeft:
                        return statsCar.CurrentDirection = CurrentDirection.South;
                    case CarActions.TurnRight:
                        return statsCar.CurrentDirection = CurrentDirection.North;
                }
            }
            if (statsCar.CurrentDirection == CurrentDirection.South)
            {
                switch (carActions)
                {
                    case CarActions.TurnLeft:
                        return statsCar.CurrentDirection = CurrentDirection.East;
                    case CarActions.TurnRight:
                        return statsCar.CurrentDirection = CurrentDirection.West;
                }
            }
            if (statsCar.CurrentDirection == CurrentDirection.East)
            {
                switch (carActions)
                {
                    case CarActions.TurnLeft:
                        return statsCar.CurrentDirection = CurrentDirection.North;
                    case CarActions.TurnRight:
                        return statsCar.CurrentDirection = CurrentDirection.South;
                }
            }
            return statsCar.CurrentDirection;
        }
        public Car SetCarStats(Car statsCar, CarActions carAction)
        {
            if (statsCar.Fuel <= 0 && carAction != CarActions.FillUpGas) { statsCar.Fuel = 0; return statsCar; }
            switch (carAction)
            {
                case CarActions.TurnLeft:
                case CarActions.TurnRight:
                    statsCar.Fuel -= 1;
                    break;
                case CarActions.DriveForwards:
                    statsCar.Fuel -= 5;
                    break;
                case CarActions.DriveBackwards:
                    statsCar.Fuel -= 3;
                    break;
                case CarActions.FillUpGas:
                    statsCar.Fuel = 100;
                    break;
            }
            return statsCar;
        }
        public Driver SetDriverStats(Driver statsDriver, DriverActions driverAction)
        {
            if (statsDriver.Tiredness >= 100 && driverAction != DriverActions.Rest) { statsDriver.Tiredness = 100; return statsDriver; }
            switch (driverAction)
            {
                case DriverActions.Drive:
                    statsDriver.Tiredness += 3;
                    statsDriver.Hunger += 1;
                    break;
                case DriverActions.FillUpGas:
                    statsDriver.Tiredness += 4;
                    statsDriver.Hunger += 1;
                    break;
                case DriverActions.Eat:
                    statsDriver.Tiredness += 8;
                    statsDriver.Hunger = 0;
                    break;
                case DriverActions.Rest:
                    statsDriver.Tiredness = 0;
                    break;
            }
            return statsDriver;
        }
    }
}
