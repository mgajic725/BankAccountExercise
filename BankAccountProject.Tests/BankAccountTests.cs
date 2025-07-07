namespace BankAccountProject.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void Constructor_SetsAccountNumberAndInitialBalance()
        {
            var account = new BankAccount("12345", 100m);

            Assert.Equal("12345", account.AccountNumber);
            Assert.Equal(100m, account.Balance);
        }

        [Fact]
        public void Deposit_AddsAmountToBalance()
        {
            var account = new BankAccount("12345", 50m);

            account.Deposit(25m);

            Assert.Equal(75m, account.Balance);
        }

        [Fact]
        public void Deposit_NegativeAmount_ThrowsArgumentException()
        {
            var account = new BankAccount("12345");

            Assert.Throws<ArgumentException>(() => account.Deposit(-10m));
        }

        [Fact]
        public void Withdraw_SubtractsAmountFromBalance()
        {
            var account = new BankAccount("12345", 100m);

            account.Withdraw(40m);

            Assert.Equal(60m, account.Balance);
        }

        [Fact]
        public void Withdraw_ZeroOrNegativeAmount_ThrowsArgumentException()
        {
            var account = new BankAccount("12345", 100m);

            Assert.Throws<ArgumentException>(() => account.Withdraw(0m));
            Assert.Throws<ArgumentException>(() => account.Withdraw(-5m));
        }

        [Fact]
        public void Withdraw_InsufficientFunds_ThrowsInsufficientFundsException()
        {
            var account = new BankAccount("12345", 20m);

            Assert.Throws<InsufficientFundsException>(() => account.Withdraw(50m));
        }

        [Fact]
        public void Transfer_MovesFundsBetweenAccounts()
        {
            var source = new BankAccount("A", 100m);
            var target = new BankAccount("B", 50m);

            source.Transfer(target, 30m);

            Assert.Equal(70m, source.Balance);
            Assert.Equal(80m, target.Balance);
        }

        [Fact]
        public void Transfer_NullTarget_ThrowsArgumentNullException()
        {
            var source = new BankAccount("A", 100m);

            Assert.Throws<ArgumentNullException>(() => source.Transfer(null, 10m));
        }

        [Fact]
        public void Transfer_SameAccount_ThrowsInvalidOperationException()
        {
            var account = new BankAccount("A", 100m);

            Assert.Throws<InvalidOperationException>(() => account.Transfer(account, 10m));
        }

        [Fact]
        public void Transfer_InsufficientFunds_ThrowsInsufficientFundsException()
        {
            var source = new BankAccount("A", 10m);
            var target = new BankAccount("B", 50m);

            Assert.Throws<InsufficientFundsException>(() => source.Transfer(target, 20m));
        }

        [Fact]
        public void Transfer_NegativeOrZeroAmount_ThrowsArgumentException()
        {
            var source = new BankAccount("A", 100m);
            var target = new BankAccount("B", 50m);

            Assert.Throws<ArgumentException>(() => source.Transfer(target, 0m));
            Assert.Throws<ArgumentException>(() => source.Transfer(target, -5m));
        }
    }
}