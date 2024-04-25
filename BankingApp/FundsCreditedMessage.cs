using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class FundsCreditedMessage
    {
        public string SenderAccountNumber { get; set; }
        public string RecipientAccountNumber { get; set; }
        public decimal Amount { get; set; }

        public FundsCreditedMessage(string senderAccountNumber, string recipientAccountNumber, decimal amount)
        {
            SenderAccountNumber = senderAccountNumber;
            RecipientAccountNumber = recipientAccountNumber;
            Amount = amount;
        }
    }
}
