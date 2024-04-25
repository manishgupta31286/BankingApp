using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts;

        public AccountRepository()
        {
            _accounts = new List<Account>();
        }

        public Task<Account> GetAccountByNumber(string accountNumber)
        {
            var account= _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
            return Task.FromResult(account);
        }

        public Task UpdateAccount(Account account)
        {
            var existingAccount = _accounts.FirstOrDefault(x => x.AccountNumber == account.AccountNumber);
            if (existingAccount != null)
            {
                existingAccount.Balance = account.Balance;
            }
            return Task.CompletedTask;
        }
    }
}
