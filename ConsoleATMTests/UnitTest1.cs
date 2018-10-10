using System;
using Xunit;
using ConsoleATM;

namespace ConsoleATMTests
{
    public class UnitTest1 
    {
        [Fact]
        public void ReturnDefaultBalance()
        {
            Account acct = new Account();
            Assert.Equal(0, acct.GetBalance());
        }


        [Fact]
        public void IncreaseBalanceBy100()
        {
            Account acct = new Account();
            acct.CreditAccount(100);
            Assert.Equal(0 + 100, acct.GetBalance());
        }

        [Fact]
        public void DecreaseBalanceBy100()
        {
            Account acct = new Account();
            acct.CreditAccount(1000);
            acct.DebitAccount(100);
            Assert.Equal(1000 - 100, acct.GetBalance());
        }

        [Fact]
        public void CanWithdraw5()
        {
            Account acct = new Account();
            acct.CreditAccount(1000);
            Program.WithdrawFrom(acct, 5);
            Assert.Equal(1000 - 5, acct.GetBalance());
        }
        [Fact]
        public void CantWithdrawNegative5()
        {
            Account acct = new Account();
            acct.CreditAccount(1000);
            Exception ex = Assert.Throws<Exception>(() => Program.WithdrawFrom(acct, -5));
            Assert.Equal("The sum couldn't be negative", ex.Message);
        }

        [Fact]
        public void CanDeposit5()
        {
            Account acct = new Account();
            Program.DepositTo(acct, 5);
            Assert.Equal(0 + 5, acct.GetBalance());
        }
    }
}
