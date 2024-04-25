using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    [Serializable]
    public class TransferRequestMessage
    {
        public string SenderAccountNumber { get; set; }
        public string RecipientAccountNumber { get; set; }
        public decimal Amount { get; set; }
        // Additional properties such as transfer date, reference number, etc.

        public TransferRequestMessage(string senderAccountNumber, string recipientAccountNumber, decimal amount)
        {
            SenderAccountNumber = senderAccountNumber;
            RecipientAccountNumber = recipientAccountNumber;
            Amount = amount;
        }
    }
}
