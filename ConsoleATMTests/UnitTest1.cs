using System;
using Xunit;
using ConsoleATM;

namespace ConsoleATMTests
{
    public class UnitTest1 : Program
    {
        [Fact]
        public void ReturnBalance()
        {
            _accountBalance = 5000;
            Assert.Equal(5000, GetBalance());
        }

        [Fact]
        public void DecreaseBalance()
        {
            decimal accountBalanceValue = 5000;
            _accountBalance = accountBalanceValue;
            DebitAccount(100);
            Assert.Equal(accountBalanceValue - 100, GetBalance());
        }

        [Fact]
        public void IncreaseBalance()
        {
            decimal accountBalanceValue = 5000;
            _accountBalance = accountBalanceValue;
            CreditAccount(100);
            Assert.Equal(accountBalanceValue + 100, GetBalance());
        }
    }
}
