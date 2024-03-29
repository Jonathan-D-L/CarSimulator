﻿using ServiceLibrary.Models;
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
            switch (statsCar.CurrentDirection)
            {
                case CurrentDirection.North:
                    switch (carActions)
                    {
                        case CarActions.TurnLeft:
                            return statsCar.CurrentDirection = CurrentDirection.West;
                        case CarActions.TurnRight:
                            return statsCar.CurrentDirection = CurrentDirection.East;
                    }

                    break;
                case CurrentDirection.West:
                    switch (carActions)
                    {
                        case CarActions.TurnLeft:
                            return statsCar.CurrentDirection = CurrentDirection.South;
                        case CarActions.TurnRight:
                            return statsCar.CurrentDirection = CurrentDirection.North;
                    }

                    break;
                case CurrentDirection.South:
                    switch (carActions)
                    {
                        case CarActions.TurnLeft:
                            return statsCar.CurrentDirection = CurrentDirection.East;
                        case CarActions.TurnRight:
                            return statsCar.CurrentDirection = CurrentDirection.West;
                    }

                    break;
                case CurrentDirection.East:
                    switch (carActions)
                    {
                        case CarActions.TurnLeft:
                            return statsCar.CurrentDirection = CurrentDirection.North;
                        case CarActions.TurnRight:
                            return statsCar.CurrentDirection = CurrentDirection.South;
                    }

                    break;
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
                case CarActions.DriveForward:
                    statsCar.Fuel -= 5;
                    break;
                case CarActions.DriveBackward:
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
                    statsDriver.Hunger += 1;
                    break;
            }
            return statsDriver;
        }

        public void PreventStatOverflow(Driver statsDriver)
        {
            SetDriverStats(statsDriver, DriverActions.Default);
        }
    }
}
