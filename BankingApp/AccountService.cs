using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task DeductFunds(string accountNumber, decimal amount)
        {
            // Retrieve the account from the repository
            var account = await _accountRepository.GetAccountByNumber(accountNumber);

            // Deduct funds from the account
            if (account.Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds in the account.");
            }

            account.Balance -= amount;

            // Update the account balance
            await _accountRepository.UpdateAccount(account);

            Console.WriteLine($"funds debited, balance amount: {account.Balance}");
        }

        public async Task CreditFunds(string accountNumber, decimal amount)
        {
            // Retrieve the account from the repository
            var account = await _accountRepository.GetAccountByNumber(accountNumber);
            if (account == null)
            {
                throw new ArgumentException($"Account with number {accountNumber} not found.");
            }

            // Credit funds to the account
            account.Balance += amount;

            // Update the account balance
            await _accountRepository.UpdateAccount(account);
            Console.WriteLine($"funds credited, balance amount: {account.Balance}");
        }
    }
}
