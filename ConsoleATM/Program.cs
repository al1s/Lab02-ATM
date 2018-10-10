using System;

namespace ConsoleATM
{
    public class Account
    {
        protected decimal _accountBalance = default(decimal);
        public decimal GetBalance()
        {
            return _accountBalance;
        }
        public void DebitAccount(decimal value)
        {
            decimal result = _accountBalance - value;
            if (result < 0) throw new Exception("Can't debit account below zero");
            else _accountBalance = result;
        }
        public void CreditAccount(decimal value)
        {
            decimal result = _accountBalance + value;
            _accountBalance = result;
        }
    }
    public class Program
    {
        public static void WithdrawFrom(Account acct, decimal amount)
        {
            if (amount < 0) throw new Exception("The sum couldn't be negative");
            try
            {
                acct.DebitAccount(amount);
            }
            catch (Exception ex)
            {
                reportException(ex); 
            }
        }
        public static void reportException(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        static void Main(string[] args)
        {
            Account acct = new Account();
            acct.CreditAccount(100);
            WithdrawFrom(acct, -6);
            Console.ReadKey();
        }
    }
}
