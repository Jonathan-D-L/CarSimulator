using Moq;
using ServiceLibrary.Models;
using UtilityLibrary;

namespace CarSimulator.Tests.Services;

[TestClass]
public class GetHungerWarningMoqTests
{
    private readonly Mock<IHungerService> _hungerServiceMock;
    private readonly IHungerService _hungerService;

    public GetHungerWarningMoqTests()
    {
        _hungerServiceMock = new Mock<IHungerService>();
        _hungerService = _hungerServiceMock.Object;
    }

    [TestMethod]
    public void Enum_Returns_Full_IfLessThan_6()
    {
        var hunger = Hunger.Full;
        var statsDriver = new Driver { Hunger = (Hunger)5 };

        var mockHungerService = new MockHungerService();
        _hungerServiceMock.Setup(s => s.MockHungerEnum(statsDriver)).Returns(mockHungerService.MockHungerEnum(statsDriver));
        var result = _hungerService.MockHungerEnum(statsDriver);

        Assert.AreEqual(hunger, result);
    }
    [TestMethod]
    public void Enum_Returns_Hungry_IfBetween_5_And_11()
    {
        var hunger = Hunger.Hungry;
        var statsDriver = new Driver { Hunger = (Hunger)10 };

        var mockHungerService = new MockHungerService();
        _hungerServiceMock.Setup(s => s.MockHungerEnum(statsDriver)).Returns(mockHungerService.MockHungerEnum(statsDriver));
        var result = _hungerService.MockHungerEnum(statsDriver);

        Assert.AreEqual(hunger, result);
    }
    [TestMethod]
    public void Enum_Returns_Starving_IfAbove_10()
    {
        var hunger = Hunger.Starving;
        var statsDriver = new Driver { Hunger = (Hunger)11};

        var mockHungerService = new MockHungerService();
        _hungerServiceMock.Setup(s => s.MockHungerEnum(statsDriver)).Returns(mockHungerService.MockHungerEnum(statsDriver));
        var result = _hungerService.MockHungerEnum(statsDriver);

        Assert.AreEqual(hunger, result);
    }
}

