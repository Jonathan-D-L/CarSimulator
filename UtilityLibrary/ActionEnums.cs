using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary
{
    public enum CarActions
    {
        DriveForwards,
        DriveBackwards,
        TurnLeft,
        TurnRight,
        Stop,
        Start,
        Default
    }

    public enum DriverActions
    {
        FillUpGas,
        Rest,
        Eat,
        Default
    }

    public enum CurrentDirection
    {
        North,
        South,
        West,
        East
    }
    public enum Hunger
    {
        Full = 5,
        Hungry = 10,
        Starving = 11
    }

}
