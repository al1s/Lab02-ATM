using System;

namespace ConsoleATM
{
    public class Program
    {
        protected static int _accountBalance = default(int);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static int GetBalance()
        {
            return _accountBalance;
        }
        public static void DebitAccount(int value)
        {
            int result = _accountBalance - value;
            if (result < 0) throw new Exception("Can't debit account below zero");
            else _accountBalance = result;
        }

    }
}
