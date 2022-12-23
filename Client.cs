using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    public class Client
    {
        private static ulong accountsCounter;

        private readonly Dictionary<ulong, Account> accounts = new Dictionary<ulong, Account>();

        public ulong ID { get; set; }

        public string FullName { get; set; }

        public uint Age { get; set; }
        
        public const string IdAccountAmountMessage = "no account with this id";

        

        public List<Account> GetAccounts()
        {
            return accounts.Values.ToList();
        }

        public Account GetAccount(ulong id)
        {
            Account account;
            if (!accounts.TryGetValue(id, out account))
            {
                throw new ArgumentOutOfRangeException("id", id,
                    IdAccountAmountMessage);
            }

            return account;
        }

        public void CreateAccount(Account account)
        {
            account.ID = ++accountsCounter;
            accounts[account.ID] = account;
        }
    }
}
