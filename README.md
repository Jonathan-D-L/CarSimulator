# CarSimulator
This console project contains a car simulation game, along with two test projects and two libraries.

Prerequisites
.NET Core 3.1 or later. An IDE such as Visual Studio or VSCode.

## Architecture
### Carsimulator
The Car Simulator follows a modular architecture, with separate components responsible for different aspects of the game. The main purpose of this architecture is to promote code organization, separation of concerns, and maintainability.

The Car Simulator utilizes the Dependency Injection pattern to manage dependencies between its various components. This pattern allows for loose coupling and makes it easy to swap out implementations or add new features without modifying existing code. Services such as ActionService, PromptService, and RandomDriverApiService are registered and used within the application, providing a modular and extensible design.

### ServicesLibrary: 
The ServicesLibrary is a separate library that contains the logic for the console application. It handles tasks such as displaying text prompts, managing game logic, handling API calls, and more. The purpose of this library is to abstract away the code from the main game loop, making it easier to follow the code flow and promoting separation of concerns.

### UtilityLibrary: 
The UtilityLibrary is another separate library that contains various helper methods. It includes functionalities like user input handling, text spacing, enums, and more. The purpose of this library is to abstract away code from the main game loop and the main menu, promoting code reuse and readability.

### Testing
The project includes two test projects that aim to ensure the quality and correctness of the codebase. The tests cover various aspects such as API integrations, mocking an API for testing, and testing services. The tests are implemented using frameworks such as MS Test, NUnit, and MOQ.






