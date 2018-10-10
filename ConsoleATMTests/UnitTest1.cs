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
            _accountBalance = 5000;
            DebitAccount(100);
            Assert.Equal(_accountBalance, GetBalance());
        }
    }
}
