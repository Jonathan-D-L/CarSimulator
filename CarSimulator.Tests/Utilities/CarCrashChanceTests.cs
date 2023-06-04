using UtilityLibrary;

namespace CarSimulator.Tests.Utilities;

[TestClass]
public class CarCrashChanceTests
{

    [TestMethod]
    public void CrashChance_Threshold_0()
    {
        var crashThreshold = 0;
        var result = CarCrashChance.CrashChance(crashThreshold);
        Assert.IsFalse(result);
    }
    [TestMethod]
    public void CrashChance_Threshold_Above_0()
    {
        var crashThreshold = 1;
        var results = new List<bool>();
        for (var i = 0; i < 100; i++)
        {
            var result = CarCrashChance.CrashChance(crashThreshold);
            results.Add(result);
        }
        Assert.IsTrue(results.Any(r => r));
    }
    [TestMethod]
    public void CrashChance_Threshold_100()
    {
        var crashThreshold = 100;
        var result = CarCrashChance.CrashChance(crashThreshold);
        Assert.IsTrue(result);
    }
}
