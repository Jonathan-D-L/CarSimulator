using ServiceLibrary.Models;
using UtilityLibrary;

namespace CarSimulator.Tests.Services;

public interface IHungerService
{
    Hunger MockHungerEnum(Driver statsDriver);
}