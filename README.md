# Unit Testing

This project contains unit tests for the `RookiesController`, `PersonService`, and `PersonRepository` in an ASP.NET Core MVC application (`Assignment04-05-MVC`). The tests validate the functionality of controller actions, service methods, and repository operations, ensuring robust code quality and reliability. The unit tests are designed to achieve at least **70% code coverage** for the implemented controller and business logic.

## Position

-   **Branch**: `unit_test`
-   **Folder**: `Assignment04-05-MVC`
-   **Quick Access**: [j4stVV/UnitTestAssignment](https://github.com/j4stVV/UnitTestAssignment)

## Content

### Requirement

-   Create unit tests for all actions in `RookiesController`.
-   Create unit tests for all business methods in `PersonService` used by the controller.
-   Create unit tests for all data access methods in `PersonRepository`.

### Objectives

-   Achieve at least **70% line-of-code coverage** for the controller and business logic.
-   Ensure all test cases are comprehensive, covering both success and failure scenarios.
-   Use mocking to isolate dependencies and validate behavior.

### Implementation

All test cases are located in the `Assignment04-05-MVC.Tests` project, structured as follows:

-   **GlobalTestData**: Contains mock data used across tests to simulate repository responses.
-   **Services > PersonServiceTests**:
    -   **Files (.cs)**: `CreateServiceTests.cs`, `DeleteServiceTests.cs`, `UpdateServiceTests.cs`, etc., each corresponding to a method in `PersonService`.
-   **Controllers**:
    -   **Files (.cs)**: `CreateControllerTests.cs`, `DeleteControllerTests.cs`, `DetailsControllerTests.cs`, etc., each corresponding to an action in `RookiesController`.
-   **Repositories > PersonRepositoryTests**:
    -   **Files (.cs)**: `AddTests.cs`, `RemoveTests.cs`, `GetAllTests.cs`, etc., each corresponding to a method in `PersonRepository`.

## What Did I Do?

-   **Testing Framework**: Used **xUnit** for writing and running unit tests.
-   **Validation**: Implemented validation for the `Person` class using **Data Annotation** to ensure robust input checking.
-   **Test Coverage**:
    -   Wrote test cases for all methods in `PersonService` (e.g., `Add`, `Delete`, `GetByFilter`).
    -   Wrote test cases for all actions in `RookiesController` (e.g., `Create`, `Delete`, `Details`).
    -   Wrote test cases for all methods in `PersonRepository` (e.g., `Add`, `Remove`, `GetAll`).
-   **Assertions**: Applied **FluentAssertions** for readable and expressive test assertions.
-   **Test Types**: Used both `[Fact]` for single test cases and `[Theory]` for parameterized tests.
-   **Mocking**:
    -   Mocked `PersonRepository` in `PersonService` tests using **Moq** to simulate data access.
    -   Mocked `PersonService` in `RookiesController` tests to isolate controller logic.
-   **Code Coverage**: Ensured tests cover at least 70% of the codebase, verifiable via the **Fine Code Coverage** extension.

## Step by Step

### Clone the Repository
    ```bash
    git clone https://github.com/j4stVV/UnitTestAssignment.git
    
    ```    

### To Run Test Cases

1.  Open the solution (`ASP.NETCoreMVCAssignment1.QuachVanViet.sln`) in **Visual Studio**.
2.  Navigate to the **Test** tab and select **Run All Tests** in the Test Explorer.
3.  View test results in the Test Explorer, which will indicate passed or failed tests.

### To See Code Coverage

1.  Install the **Fine Code Coverage (FCC)** extension in Visual Studio.
2.  Go to **View > Other Windows > Fine Code Coverage** to open the FCC window.
3.  Run all test cases again via the Test Explorer.
4.  Check the FCC window for a detailed code coverage report (target: ≥70%).

### To Run the Application

1.  Open the solution (`ASP.NETCoreMVCAssignment1.QuachVanViet.sln`) in **Visual Studio**.
2.  Click the **Run** (▶️) button to start the application.
3.  Access the application via the browser.

## Technologies Used

-   **.NET 8.0**: Runtime for the ASP.NET Core MVC application.
-   **xUnit**: Testing framework for unit tests.
-   **Moq**: Mocking library for simulating dependencies.
-   **FluentAssertions**: Library for expressive assertions.
-   **Entity Framework Core (In-Memory)**: Used in `PersonRepository` tests to simulate database operations.

## Contributing

Contributions are welcome! To contribute:

1.  Fork the repository.
2.  Create a new branch (`git checkout -b feature/your-feature`).
3.  Add your changes or additional test cases.
4.  Commit your changes (`git commit -m "Add your feature"`).
5.  Push to the branch (`git push origin feature/your-feature`).
6.  Open a Pull Request.

Ensure all tests pass and maintain the 70% code coverage target.

## License

This project is licensed under the MIT License. See the [LICENSE](https://grok.com/chat/LICENSE) file for details.