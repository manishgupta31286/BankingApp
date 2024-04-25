namespace BankingApp
{
    public class TransferRequest
    {
        public string SenderAccountNumber { get; set; }
        public string RecipientAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
