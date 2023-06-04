using UtilityLibrary;

namespace CarSimulator.Tests.Utilities;



[TestClass]
public class TextSpacerTests
{
    [TestMethod]
    public void TextSpace_Returns_Correct_Spacing_Int()
    {
        var spaceAmount = 10;
        var subtractAmount = 9;
        var expectedResult = spaceAmount - subtractAmount;
        var result = TextSpacer.SpaceText(spaceAmount, subtractAmount);
        Assert.AreEqual(expectedResult, result.Length);
    }
    [TestMethod]
    public void TextSpace_Returns_Correct_Spacing_String()
    {
        var spaceAmount = 10;
        var subtractAmount = "NINE TEST";
        var expectedResult = spaceAmount - subtractAmount.Length;
        var result = TextSpacer.SpaceText(spaceAmount, subtractAmount);
        Assert.AreEqual(expectedResult, result.Length);
    }
}