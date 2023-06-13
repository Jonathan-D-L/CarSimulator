using ServiceLibrary.Models;
using UtilityLibrary;

namespace CarSimulator.Tests.Services;

public class MockHungerService : IHungerService
{
    public Hunger MockHungerEnum(Driver statsDriver)
    {
        switch (statsDriver.Hunger)
        {
            case <= (Hunger)5:
                return Hunger.Full;
            case > (Hunger)5 and <= (Hunger)10:
                return Hunger.Hungry;
            case > (Hunger)10:
                return Hunger.Starving;
        }
    }
}