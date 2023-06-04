using System.Reflection.Metadata;
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
        Assert.IsFalse(result, "Expected probability to be 0%");
    }
    [TestMethod]
    public void CrashChance_Threshold_Probability_For_1()
    {
        var threshold = 1;
        var numCalls = 100;
        var numTrials = 1000;
        var numSuccesses = 0;
        for (int i = 0; i < numTrials; i++)
        {
            var hasTrueResult = false;
            for (int j = 0; j < numCalls; j++)
            {
                var result = CarCrashChance.CrashChance(threshold);
                if (result)
                {
                    hasTrueResult = true;
                    break;
                }
            }
            if (hasTrueResult)
            {
                numSuccesses++;
            }
        }
        var probability = (double)numSuccesses / numTrials;
        Assert.IsTrue(probability > 0.6, "Expected probability to be greater than 60%");
    }
    [TestMethod]
    public void CrashChance_Threshold_100()
    {
        var crashThreshold = 100;
        var result = CarCrashChance.CrashChance(crashThreshold);
        Assert.IsTrue(result, "Expected probability to be 100%");
    }
}
