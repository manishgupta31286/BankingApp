using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public interface IAccountService
    {
        Task DeductFunds(string accountNumber, decimal amount);
        Task CreditFunds(string accountNumber, decimal amount);
    }
}
