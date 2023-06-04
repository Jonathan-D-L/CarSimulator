using ServiceLibrary;
using ServiceLibrary.Models;
using UtilityLibrary;

namespace CarSimulator.Tests.Services
{
    [TestClass]
    public class SetDriverStatsTests
    {
        private readonly IActionService _sut;

        public SetDriverStatsTests()
        {
            _sut = new ActionService();
        }

        [TestMethod]
        public void SetDriverStats_Tiredness_Increases_When_Drive()
        {
            var statsDriver = new Driver { Tiredness = 0 };
            var tirednessBefore = statsDriver.Tiredness;
            var driverAction = DriverActions.Drive;
            var result = _sut.SetDriverStats(statsDriver, driverAction);
            Assert.IsTrue(tirednessBefore < result.Tiredness);
        }
        [TestMethod]
        public void SetDriverStats_Tiredness_Increases_When_FillUpGas()
        {
            var statsDriver = new Driver { Tiredness = 0 };
            var tirednessBefore = statsDriver.Tiredness;
            var driverAction = DriverActions.FillUpGas;
            var result = _sut.SetDriverStats(statsDriver, driverAction);
            Assert.IsTrue(tirednessBefore < result.Tiredness);
        }
        [TestMethod]
        public void SetDriverStats_Tiredness_Increases_When_Eat()
        {
            var statsDriver = new Driver { Tiredness = 0 };
            var tirednessBefore = statsDriver.Tiredness;
            var driverAction = DriverActions.Eat;
            var result = _sut.SetDriverStats(statsDriver, driverAction);
            Assert.IsTrue(tirednessBefore < result.Tiredness);
        }
        [TestMethod]
        public void SetDriverStats_Tiredness_Reset_When_Rest()
        {
            var statsDriver = new Driver { Tiredness = 99 };
            var driverAction = DriverActions.Rest;
            var result = _sut.SetDriverStats(statsDriver, driverAction);
            Assert.AreEqual(0, result.Tiredness);
        }
        [TestMethod]
        public void SetDriverStats_Hunger_Increases_When_Drive()
        {
            var statsDriver = new Driver { Hunger = 0 };
            var hungerBefore = statsDriver.Hunger;
            var driverAction = DriverActions.Drive;
            var result = _sut.SetDriverStats(statsDriver, driverAction);
            Assert.IsTrue(hungerBefore < result.Hunger);
        }
        [TestMethod]
        public void SetDriverStats_Hunger_Increases_When_FillUpGas()
        {
            var statsDriver = new Driver { Hunger = 0 };
            var hungerBefore = statsDriver.Hunger;
            var driverAction = DriverActions.FillUpGas;
            var result = _sut.SetDriverStats(statsDriver, driverAction);
            Assert.IsTrue(hungerBefore < result.Hunger);
        }
        [TestMethod]
        public void SetDriverStats_Hunger_Increases_When_Eat()
        {
            var statsDriver = new Driver { Hunger = 0 };
            var hungerBefore = statsDriver.Hunger;
            var driverAction = DriverActions.Rest;
            var result = _sut.SetDriverStats(statsDriver, driverAction);
            Assert.IsTrue(hungerBefore < result.Hunger);
        }
        [TestMethod]
        public void SetDriverStats_Hunger_Reset_When_Rest()
        {
            var statsDriver = new Driver { Hunger = Hunger.Starving };
            var driverAction = DriverActions.Eat;
            var result = _sut.SetDriverStats(statsDriver, driverAction);
            Assert.AreEqual(Hunger.Default, result.Hunger);
        }
    }
}
