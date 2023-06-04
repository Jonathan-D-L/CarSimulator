using ServiceLibrary.Models;
using ServiceLibrary;
using UtilityLibrary;

namespace CarSimulator.Tests.Services;
[TestClass]
public class GetTirednessWarningTests
{
    private readonly PromptService _sut;
    public GetTirednessWarningTests()
    {
        _sut = new PromptService();
    }

    [TestMethod]
    public void GetHungerWarning_Tiredness_0()
    {
        var statsDriver = new Driver { Tiredness = 0 };
        var result = _sut.GetTirednessWarning(statsDriver);
        Assert.IsTrue(string.IsNullOrWhiteSpace(result));
    }
    [TestMethod]
    public void GetHungerWarning_Tiredness_70()
    {
        var statsDriver = new Driver { Tiredness = 70 };
        var result = _sut.GetTirednessWarning(statsDriver);
        Assert.IsFalse(string.IsNullOrWhiteSpace(result));
    }
}