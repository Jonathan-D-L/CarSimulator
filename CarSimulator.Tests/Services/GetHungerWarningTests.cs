using ServiceLibrary;
using ServiceLibrary.Models;
using UtilityLibrary;

namespace CarSimulator.Tests.Services;

[TestClass]
public class GetHungerWarningTests
{
    private readonly PromptService _sut;
    public GetHungerWarningTests()
    {
        _sut = new PromptService();
    }
    [TestMethod]
    public void GetHungerWarning_Hunger_Full()
    {
        var statsDriver = new Driver{ Hunger = Hunger.Full };
        var result = _sut.GetHungerWarning(statsDriver);
        Assert.IsTrue(string.IsNullOrWhiteSpace(result));
    }
    [TestMethod]
    public void GetHungerWarning_Hunger_Hungry()
    {
        var statsDriver = new Driver { Hunger = Hunger.Hungry };
        var result = _sut.GetHungerWarning(statsDriver);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result));
    }
    [TestMethod]
    public void GetHungerWarning_Hunger_Starving()
    {
        var statsDriver = new Driver { Hunger = Hunger.Starving };
        var result = _sut.GetHungerWarning(statsDriver);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result));
    }
}