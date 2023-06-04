using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary
{
    public enum CarActions
    {
        Default,
        DriveForward,
        DriveBackward,
        TurnLeft,
        TurnRight,
        FillUpGas,
        Start,
        Stop
    }

    public enum DriverActions
    {
        Default,
        Drive,
        FillUpGas,
        Rest,
        Eat
    }

    public enum CurrentDirection
    {
        Default,
        North,
        South,
        West,
        East
    }
    public enum Hunger
    {
        Default = 0,
        Full = 5,
        Hungry = 10,
        Starving = 11
    }

    public enum GameOver
    {
        Default,
        Starved,
        Crashed,
        FellAsleep
    }

}
