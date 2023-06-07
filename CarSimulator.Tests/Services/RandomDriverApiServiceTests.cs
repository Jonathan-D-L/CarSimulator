using Moq;
using ServiceLibrary.Models;
using ServiceLibrary;

namespace CarSimulator.Tests.Services;

[TestClass]
public class RandomDriverApiServiceTests
{
    private readonly Mock<IRandomDriverApiService> _randomDriverApiServiceMock;
    private readonly IRandomDriverApiService _randomDriverApiService;

    public RandomDriverApiServiceTests()
    {
        _randomDriverApiServiceMock = new Mock<IRandomDriverApiService>();
        _randomDriverApiService = _randomDriverApiServiceMock.Object;
    }


    [TestMethod]
    public async Task Get_One_Random_Driver()
    {
        var randomDriver = new Driver
        {
            GivenName = "Jon",
            SurName = "Doe"
            
        };
        _randomDriverApiServiceMock.Setup(repo => repo.GetRandomDriver()).ReturnsAsync(randomDriver);
        var result = await _randomDriverApiService.GetRandomDriver();
        Assert.AreEqual(randomDriver, result);
    }
    [TestMethod]
    public async Task Get_Random_Driver_Returns_Valid_Driver()
    {
        var randomDriverApiService = new RandomDriverApiService();
        var result = await randomDriverApiService.GetRandomDriver();

        Assert.IsNotNull(result);
        Assert.IsFalse(string.IsNullOrEmpty(result.GivenName));
        Assert.IsFalse(string.IsNullOrEmpty(result.SurName));
    }

}