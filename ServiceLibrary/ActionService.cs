using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
