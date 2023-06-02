using Microsoft.Extensions.DependencyInjection;
using ServiceLibrary;
using UtilityLibrary;

namespace CarSimulator;

public class CarSimApp
{
    private readonly CarGame _carGame;
    private readonly IPromptService _promptService;

    public CarSimApp(CarGame carGame,IPromptService promptService)
    {
        _carGame = carGame;
        _promptService = promptService;
    }

    public void Run()
    {
        var selector = 0;

        Console.CursorVisible = false;
        while (true)
        {
            var options = _promptService.GetStartOptions();
            var prompt = _promptService.GetGameTitle();
            prompt += _promptService.GetStartPrompt();
            selector = Selector.GetSelections(selector, options, prompt, string.Empty, new List<string>());
            if (selector == 0)
            {
                _carGame.Game();
            }
            if (selector == 1)
            {
                break;
            }
        }
    }
}