using Moq;
using ServiceLibrary.Models;
using UtilityLibrary;

namespace CarSimulator.Tests.Services;

[TestClass]
public class GetHungerWarningMoqTests
{
    private readonly Mock<IHungerService> _hungerServiceMock;
    private readonly IHungerService _sut;

    public GetHungerWarningMoqTests()
    {
        _hungerServiceMock = new Mock<IHungerService>();
        _sut = _hungerServiceMock.Object;
    }

    [TestMethod]
    public void Enum_Returns_Full_IfLessThan_6()
    {
        var expected = Hunger.Full;
        var statsDriver = new Driver { Hunger = (Hunger)5 };

        _hungerServiceMock.Setup(s => s.MockHungerEnum(statsDriver)).Returns(expected);
        var result = _sut.MockHungerEnum(statsDriver);

        Assert.AreEqual(expected, result);
    }
    [TestMethod]
    public void Enum_Returns_Hungry_IfBetween_5_And_11()
    {
        var expected = Hunger.Hungry;
        var statsDriver = new Driver { Hunger = (Hunger)10 };

        _hungerServiceMock.Setup(s => s.MockHungerEnum(statsDriver)).Returns(expected);
        var result = _sut.MockHungerEnum(statsDriver);

        Assert.AreEqual(expected, result);
    }
    [TestMethod]
    public void Enum_Returns_Starving_IfAbove_10()
    {
        var expected = Hunger.Starving;
        var statsDriver = new Driver { Hunger = (Hunger)11};

        _hungerServiceMock.Setup(s => s.MockHungerEnum(statsDriver)).Returns(expected);
        var result = _sut.MockHungerEnum(statsDriver);

        Assert.AreEqual(expected, result);
    }
}

