using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models;
using UtilityLibrary;

namespace ServiceLibrary
{
    public interface IActionService
    {
        Car GetCarStats();
        Driver GetDriverStats();
        CurrentDirection GetCurrentDirection(Car statsCar, CarActions carActions);
        Car SetCarStats(Car statsCar, CarActions carAction);
        Driver SetDriverStats(Driver statsDriver, DriverActions driverAction);
    }
}
