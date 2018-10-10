using System;

namespace ConsoleATM
{
    public class Program
    {
        protected static decimal _accountBalance = default(int);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static decimal GetBalance()
        {
            return _accountBalance;
        }
        public static void DebitAccount(decimal value)
        {
            decimal result = _accountBalance - value;
            if (result < 0) throw new Exception("Can't debit account below zero");
            else _accountBalance = result;
        }
        public static void CreditAccount(decimal value)
        {
            decimal result = _accountBalance + value;
            _accountBalance = result;
        }
    }
}
