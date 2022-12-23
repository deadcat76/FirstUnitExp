using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Account
    {
        public List<AccountAction> history = new List<AccountAction>();
        public ulong ID { get; set; }

        public bool IsOpen { get; set; }

        public double Balance { get; set; }

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        public Account(ulong id, bool isOpen, double balance)
        {
            ID = id;
            IsOpen = isOpen;
            Balance = balance;
        }

        public List<AccountAction> GetHistory()
        {
            return history;
        }

        public void Open()
        {
            if (IsOpen)
            {
                throw new InvalidOperationException();
            }

            IsOpen = true;
        }

        public void Close()
        {
            if (!IsOpen)
            {
                throw new InvalidOperationException();
            }

            IsOpen = false;
        }

        public void MakeDeposit(double amount)
        {
            if (!IsOpen)
            {
                throw new InvalidOperationException();
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount,
                    DebitAmountLessThanZeroMessage);
            }

            Balance += amount;
            WriteHistory(ActionType.Deposit, amount);
        }

        public void MakeLoan(double amount)
        {
            if (!IsOpen)
            {
                throw new InvalidOperationException();
            }
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount,
                    DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount,
                    DebitAmountLessThanZeroMessage);
            }

            Balance -= amount;
            WriteHistory(ActionType.Loan, amount);
        }

        private void WriteHistory(ActionType type, double amount)
        {
            var action = new AccountAction
            {
                Type = type,
                Amount = amount
            };
            history.Add(action);
        }
    }
}
