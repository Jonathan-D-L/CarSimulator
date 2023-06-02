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
        FillUpGas,
        Stop,
        Start,
        Default
    }

    public enum DriverActions
    {
        Drive,
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
        East,
        Default
    }
    public enum Hunger
    {
        Full = 5,
        Hungry = 10,
        Starving = 11,
        Default = -1
    }

}
