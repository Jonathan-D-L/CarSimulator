using ServiceLibrary.Models;
using ServiceLibrary;
using UtilityLibrary;

namespace CarSimulator.Tests.Services;

public class GetGameOverMessageTests
{
    [TestClass]
    public class GetCurrentDirectionTests
    {
        private readonly PromptService _sut;

        public GetCurrentDirectionTests()
        {
            _sut = new PromptService();
        }

        [TestMethod]
        public void GetGameOverMessage_Reason_Crashed()
        {
            var statsDriver = new Driver();
            var gameOverReason = GameOver.Crashed;
            var result = _sut.GetGameOverMessage(gameOverReason, statsDriver);
            Assert.IsTrue(result.Contains(nameof(GameOver.Crashed)));
        }
        [TestMethod]
        public void GetGameOverMessage_Reason_Starved()
        {
            var statsDriver = new Driver();
            var gameOverReason = GameOver.Starved;
            var result = _sut.GetGameOverMessage(gameOverReason, statsDriver);
            Assert.IsTrue(result.Contains(nameof(GameOver.Starved)));
        }
        [TestMethod]
        public void GetGameOverMessage_Reason_Dozed_Off()
        {
            var statsDriver = new Driver();
            var gameOverReason = GameOver.Dozed;
            var result = _sut.GetGameOverMessage(gameOverReason, statsDriver);
            Assert.IsTrue(result.Contains(nameof(GameOver.Dozed)));
        }
    }
}