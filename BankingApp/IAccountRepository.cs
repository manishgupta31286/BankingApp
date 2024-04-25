using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByNumber(string accountNumber);
        Task UpdateAccount(Account account);
    }
}
