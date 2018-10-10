using System;
using Xunit;
using ConsoleATM;

namespace ConsoleATMTests
{
    public class UnitTest1
    {
        [Fact]
        public void ReturnBalance()
        {
            Program._accountBalance = 5000;
            Assert.Equal(5000, Program.GetBalance());

        }
    }
}
