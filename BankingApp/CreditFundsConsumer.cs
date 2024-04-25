using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class CreditFundsConsumer : IConsumer<TransferRequestMessage>
    {
        private readonly IAccountService _accountService;
        private readonly IBus _bus;

        public CreditFundsConsumer(IAccountService accountService,
            IBus bus)
        {
            _accountService = accountService;
            _bus = bus;
        }

        public async Task Consume(ConsumeContext<TransferRequestMessage> context)
        {
            var request = context.Message;

            await _accountService.CreditFunds(request.SenderAccountNumber, request.Amount);

            await _bus.Publish<FundsCreditedMessage>(new
            {
                SenderAccountNumber = request.SenderAccountNumber,
                RecipientAccountNumber = request.RecipientAccountNumber,
                Amount = request.Amount
            });
        }
    }
}
