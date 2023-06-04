﻿using ServiceLibrary;
using ServiceLibrary.Models;
using UtilityLibrary;

namespace CarSimulator.Tests.Services;

[TestClass]
public class GetCurrentDirectionTests
{
    private readonly IActionService _sut;

    public GetCurrentDirectionTests()
    {
        _sut = new ActionService();
    }

    [TestMethod]
    public void GetCurrentDirection_N_Turn_Left()
    {
        var statsCar = new Car { CurrentDirection = CurrentDirection.North };
        var carActions = CarActions.TurnLeft;
        var result = _sut.GetCurrentDirection(statsCar, carActions);
        Assert.AreEqual(CurrentDirection.West, result);
    }
    [TestMethod]
    public void GetCurrentDirection_N_Turn_Right()
    {
        var statsCar = new Car { CurrentDirection = CurrentDirection.North };
        var carActions = CarActions.TurnRight;
        var result = _sut.GetCurrentDirection(statsCar, carActions);
        Assert.AreEqual(CurrentDirection.East, result);
    }
    [TestMethod]
    public void GetCurrentDirection_W_Turn_Left()
    {
        var statsCar = new Car { CurrentDirection = CurrentDirection.West };
        var carActions = CarActions.TurnLeft;
        var result = _sut.GetCurrentDirection(statsCar, carActions);
        Assert.AreEqual(CurrentDirection.South, result);
    }
    [TestMethod]
    public void GetCurrentDirection_W_Turn_Right()
    {
        var statsCar = new Car { CurrentDirection = CurrentDirection.West };
        var carActions = CarActions.TurnRight;
        var result = _sut.GetCurrentDirection(statsCar, carActions);
        Assert.AreEqual(CurrentDirection.North, result);
    }
    [TestMethod]
    public void GetCurrentDirection_S_Turn_Left()
    {
        var statsCar = new Car { CurrentDirection = CurrentDirection.South };
        var carActions = CarActions.TurnLeft;
        var result = _sut.GetCurrentDirection(statsCar, carActions);
        Assert.AreEqual(CurrentDirection.East, result);
    }
    [TestMethod]
    public void GetCurrentDirection_S_Turn_Right()
    {
        var statsCar = new Car { CurrentDirection = CurrentDirection.South };
        var carActions = CarActions.TurnRight;
        var result = _sut.GetCurrentDirection(statsCar, carActions);
        Assert.AreEqual(CurrentDirection.West, result);
    }
    [TestMethod]
    public void GetCurrentDirection_E_Turn_Left()
    {
        var statsCar = new Car { CurrentDirection = CurrentDirection.East };
        var carActions = CarActions.TurnLeft;
        var result = _sut.GetCurrentDirection(statsCar, carActions);
        Assert.AreEqual(CurrentDirection.North, result);
    }
    [TestMethod]
    public void GetCurrentDirection_E_Turn_Right()
    {
        var statsCar = new Car { CurrentDirection = CurrentDirection.East };
        var carActions = CarActions.TurnRight;
        var result = _sut.GetCurrentDirection(statsCar, carActions);
        Assert.AreEqual(CurrentDirection.South, result);
    }
}