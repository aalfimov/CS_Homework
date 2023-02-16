using System;

namespace CreditCard
{
    class CreditCard
    {
        public string CardNumber { get; }
        public string CardHolderName { get; }
        public DateTime ExpirationDate { get; }
        public string PIN { get; private set; }
        public decimal CreditLimit { get; }
        public decimal Balance { get; private set; }
        public decimal CreditBalance { get; private set; }

        public event EventHandler<decimal> BalanceChanged;
        public event EventHandler<decimal> CreditBalanceChanged;
        public event EventHandler<string> PinChanged;
        public event EventHandler<string> CreditStarted;
        public event EventHandler<string> CreditLimitReached;

        public CreditCard(string cardNumber, string cardHolderName, DateTime expirationDate, string pin, decimal creditLimit)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpirationDate = expirationDate;
            PIN = pin;
            CreditLimit = creditLimit;
        }

        public void AddFunds(decimal amount)
        {
            Balance += amount;
            BalanceChanged?.Invoke(this, Balance);
        }

        public void MakePurchase(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                BalanceChanged?.Invoke(this, Balance);
            }
            else if (Balance + CreditBalance >= amount)
            {
                CreditBalance -= amount - Balance;
                Balance = 0;
                BalanceChanged?.Invoke(this, Balance);
                CreditBalanceChanged?.Invoke(this, CreditBalance);
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds");
            }
        }

        public void StartCredit(decimal amount)
        {
            if (CreditBalance > 0)
            {
                throw new InvalidOperationException("Credit is already in use");
            }

            CreditBalance = amount;
            CreditStarted?.Invoke(this, "Credit started");
            CreditBalanceChanged?.Invoke(this, CreditBalance);
        }

        public void ChangePIN(string newPin)
        {
            PIN = newPin;
            PinChanged?.Invoke(this, PIN);
        }

        public void CheckCreditLimit()
        {
            if (Balance + CreditBalance >= CreditLimit)
            {
                CreditLimitReached?.Invoke(this, "Credit limit reached");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CreditCard card = new CreditCard("1234567890123456", "John Doe", new DateTime(2025, 12, 31), "1234", 1000);

            card.BalanceChanged += (sender, balance) => Console.WriteLine($"Balance changed: {balance:C}");
            card.CreditBalanceChanged += (sender, creditBalance) => Console.WriteLine($"Credit balance changed: {creditBalance:C}");
            card.PinChanged += (sender, pin) => Console.WriteLine($"PIN changed: {pin}");
            card.CreditStarted += (sender, message) => Console.WriteLine($"Credit started: {message}");
            card.CreditLimitReached += (sender, message) => Console.WriteLine($"Credit limit reached: {message}");

            card.AddFunds(500);
            card.MakePurchase(300);
            card.StartCredit(200);
            card.CheckCreditLimit();
            card.ChangePIN("5678");
        }
    }
}
