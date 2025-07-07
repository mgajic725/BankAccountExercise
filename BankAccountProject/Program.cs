using System;

namespace BankAccountProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two bank accounts
            BankAccount account1 = new BankAccount("ACC123", 1000);
            BankAccount account2 = new BankAccount("ACC456", 500);

            Console.WriteLine("Initial Balances:");
            Console.WriteLine($"Account {account1.AccountNumber}: {account1.Balance}");
            Console.WriteLine($"Account {account2.AccountNumber}: {account2.Balance}");

            // Perform deposit on account1
            account1.Deposit(200);

            // Attempt withdrawal on account2 (should fail if funds are insufficient)
            try
            {
                account2.Withdraw(600); // This should trigger an exception for insufficient funds.
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Error during withdrawal: {ex.Message}");
            }

            // Perform transfer from account1 to account2
            try
            {
                account1.Transfer(account2, 300);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during transfer: {ex.Message}");
            }

            Console.WriteLine("Final Balances:");
            Console.WriteLine($"Account {account1.AccountNumber}: {account1.Balance}");
            Console.WriteLine($"Account {account2.AccountNumber}: {account2.Balance}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
