# BankAccountProject

## Purpose

This project provides a simple C# library for modeling a bank account with core operations such as deposit, withdrawal, and transfer. It demonstrates best practices in validation, exception handling, and unit testing using xUnit.

## Summary of Changes

- **Validation Added:**  
  - Deposit now throws an `ArgumentException` if the amount is less than zero.
  - Withdraw now throws an `ArgumentException` if the amount is less than or equal to zero, and an `InsufficientFundsException` if the withdrawal exceeds the current balance.
  - Transfer now throws:
    - `ArgumentNullException` if the target account is null,
    - `InvalidOperationException` if attempting to transfer to the same account,
    - `ArgumentException` if the amount is less than or equal to zero,
    - `InsufficientFundsException` if the source account lacks sufficient funds.
- **Custom Exception:**  
  - `InsufficientFundsException` was introduced for handling overdraft attempts.
- **Unit Tests:**  
  - Comprehensive xUnit tests were added to verify all validation and business logic.

## How to Run the Application

1. **Open the Solution:**  
   Open the solution in Visual Studio 2022 or later.

2. **Build the Solution:**  
   Use `Ctrl+Shift+B` or select **Build Solution** from the Build menu.

3. **Run the Application:**  
   - Set `BankAccountProject` as the startup project.
   - Press `F5` or select **Start Debugging** to run the application.
   - The `Program.cs` file can be modified to experiment with the `BankAccount` class.

## How to Run the Unit Tests

1. **Using Visual Studio Test Explorer:**  
   - Open the **Test Explorer** window (`Test > Test Explorer`).
   - Click **Run All** to execute all tests in the `BankAccountProject.Tests` project.

2. **Using the .NET CLI:**  
   - Open a terminal in the project root.
   - Run:
     ```
     dotnet test
     ```