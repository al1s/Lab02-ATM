using System;

namespace ConsoleATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            Account acct = new Account();
            acct.CreditAccount(100);
            DisplayInitialScreen(acct);
        }
        public static void WithdrawFrom(Account acct, decimal amount)
        {
            if (amount < 0) throw new Exception("The sum couldn't be negative");
            try
            {
                acct.DebitAccount(amount);
            }
            catch (Exception ex)
            {
                ReportException(ex); 
            }
        }
        public static void DepositTo(Account acct, decimal amount)
        {
            try
            {
                acct.CreditAccount(amount);
            }
            catch (Exception ex)
            {
                ReportException(ex);
            }
        }
        public static void ReportException(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        public static void DisplayInitialScreen(Account acct)
        {
            Console.WriteLine("Your Bank ATM");
            Console.WriteLine("Choose operation");
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Deposit Money");
            Console.WriteLine("4. Exit");
            HandleInput(acct, GetInput(), "initial");
        }

        // Get only numeric input, Backspace and Enter
        public static string GetInput()
        {
            // storage for input result 
            string userInput = string.Empty;
            ConsoleKeyInfo pressed;
            // while not pressed Enter
            do
            {
                pressed = Console.ReadKey(true);
                // check whether the key pressed a number or not
                if (pressed.Key != ConsoleKey.Backspace)
                {
                    int value = default(int);
                    if (int.TryParse(pressed.KeyChar.ToString(), out value))
                    {
                        userInput += pressed.KeyChar;
                        Console.Write(pressed.KeyChar);
                    }
                }
                else
                {
                    // the user want do delete the last char
                    if (pressed.Key == ConsoleKey.Backspace && userInput.Length != 0)
                    {
                        // sync storage and screen 
                        userInput = userInput.Substring(0, userInput.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            } while (pressed.Key != ConsoleKey.Enter);
            return userInput;
        }

        public static void HandleInput(Account acct, string userInput, string screen)
        {
            switch (screen)
            {
                case "initial":
                    switch (userInput)
                    {
                        case "1":
                            DisplayBalanceScreen();
                            break;
                        case "2":
                            DisplayWithdrawScreen();
                            break;
                        case "3":
                            DisplayDepositScreen();
                            break;
                        case "4":
                            Environment.Exit(0);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                    break;
                case "withdraw":
                    WithdrawFrom(acct, decimal.Parse(userInput));
                    break;
                case "deposit":
                    DepositTo(acct, decimal.Parse(userInput));
                    break;
            }
        }

        public static void DisplayBalanceScreen()
        {

        }

        public static void DisplayWithdrawScreen() { }

        public static void DisplayDepositScreen() { }
    }
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
}
