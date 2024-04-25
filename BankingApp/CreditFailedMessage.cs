using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class CreditFailedMessage
    {
        public string SenderAccountNumber { get; set; }
        public string RecipientAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Message { get; set; }
        public CreditFailedMessage(string senderAccountNumber, 
            string recipientAccountNumber, 
            decimal amount,string message)
        {
            SenderAccountNumber = senderAccountNumber;
            RecipientAccountNumber = recipientAccountNumber;
            Amount = amount;
            Message = message;
        }
    }
}
