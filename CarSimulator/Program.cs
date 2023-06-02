using CarSimulator;
using Microsoft.Extensions.DependencyInjection;
using ServiceLibrary;


var services = new ServiceCollection();
services.AddTransient<IActionService, ActionService>();
services.AddTransient<IPromptService, PromptService>();
services.AddTransient<CarGame>();
services.AddTransient<CarSimApp>();
var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetService<CarSimApp>();
app.Run();