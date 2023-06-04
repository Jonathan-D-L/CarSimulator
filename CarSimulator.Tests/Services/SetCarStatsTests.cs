using ServiceLibrary;
using ServiceLibrary.Models;
using UtilityLibrary;

namespace CarSimulator.Tests.Services;

[TestClass]
public class SetCarStatsTests
{
    private readonly IActionService _sut;

    public SetCarStatsTests()
    {
        _sut = new ActionService();
    }
    [TestMethod]
    public void SetCarStats_Fuel_Decrease_When_TurnLeft()
    {
        var statsCar = new Car { Fuel = 100 };
        var fuelBefore = statsCar.Fuel;
        var carAction = CarActions.TurnLeft;
        var result = _sut.SetCarStats(statsCar, carAction);
        Assert.IsTrue(fuelBefore > result.Fuel);
    }
    [TestMethod]
    public void SetCarStats_Fuel_Decrease_When_TurnRight()
    {
        var statsCar = new Car { Fuel = 100 };
        var fuelBefore = statsCar.Fuel;
        var carAction = CarActions.TurnRight;
        var result = _sut.SetCarStats(statsCar, carAction);
        Assert.IsTrue(fuelBefore > result.Fuel);
    }
    [TestMethod]
    public void SetCarStats_Fuel_Decrease_When_DriveForward()
    {
        var statsCar = new Car { Fuel = 100 };
        var fuelBefore = statsCar.Fuel;
        var carAction = CarActions.DriveForward;
        var result = _sut.SetCarStats(statsCar, carAction);
        Assert.IsTrue(fuelBefore > result.Fuel);
    }
    [TestMethod]
    public void SetCarStats_Fuel_Decrease_When_DriveBackward()
    {
        var statsCar = new Car { Fuel = 100 };
        var fuelBefore = statsCar.Fuel;
        var carAction = CarActions.DriveBackward;
        var result = _sut.SetCarStats(statsCar, carAction);
        Assert.IsTrue(fuelBefore > result.Fuel);
    }
    [TestMethod]
    public void SetCarStats_Fuel_Full_When_FillUpGas()
    {
        var statsCar = new Car { Fuel = 10 };
        var carAction = CarActions.FillUpGas;
        var result = _sut.SetCarStats(statsCar, carAction);
        Assert.AreEqual(100, result.Fuel);
    }
}