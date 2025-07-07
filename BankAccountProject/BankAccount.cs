using System;

namespace BankAccountProject
{
    public class BankAccount
    {
        /// <summary>
        /// Gets or sets the account number for this bank account.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets the current balance of the account.
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class with a specified account number and optional initial balance.
        /// </summary>
        /// <param name="accountNumber">The account number for the bank account.</param>
        /// <param name="initialBalance">The initial balance for the account. Defaults to 0.</param>
        public BankAccount(string accountNumber, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        /// <summary>
        /// Deposits a specified amount into the account.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="amount"/> is less than zero.</exception>
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.", nameof(amount));
            }

            Balance += amount;
        }

        /// <summary>
        /// Withdraws a specified amount from the account.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="amount"/> is less than or equal to zero.</exception>
        /// <exception cref="InsufficientFundsException">Thrown if the account does not have enough funds to complete the withdrawal.</exception>
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.", nameof(amount));
            }

            if (amount > Balance)
            {
                throw new InsufficientFundsException("Not enough funds to withdraw.");
            }

            Balance -= amount;
        }

        /// <summary>
        /// Transfers a specified amount from this account to a target account.
        /// </summary>
        /// <param name="targetAccount">The account to transfer the amount to.</param>
        /// <param name="amount">The amount to transfer.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="targetAccount"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if attempting to transfer to the same account.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="amount"/> is less than or equal to zero.</exception>
        /// <exception cref="InsufficientFundsException">Thrown if the account does not have enough funds to complete the transfer.</exception>
        /// <remarks>
        /// The transfer operation is not atomic; if the withdrawal succeeds but the deposit fails,
        /// the accounts may be left in an inconsistent state.
        /// </remarks>
        public void Transfer(BankAccount targetAccount, decimal amount)
        {
            if (targetAccount == null)
            {
                throw new ArgumentNullException(nameof(targetAccount), "Target account cannot be null.");
            }

            if (ReferenceEquals(this, targetAccount))
            {
                throw new InvalidOperationException("Cannot transfer to the same account.");
            }

            Withdraw(amount);
            targetAccount.Deposit(amount);
        }
    }
}