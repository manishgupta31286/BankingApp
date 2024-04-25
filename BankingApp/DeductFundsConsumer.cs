using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class DeductFundsConsumer : IConsumer<TransferRequestMessage>
    {
        private readonly IAccountService _accountService;
        private readonly IBus _bus;

        public DeductFundsConsumer(IAccountService accountService,IBus bus)
        {
            _accountService = accountService;
            _bus = bus;
        }

        public async Task Consume(ConsumeContext<TransferRequestMessage> context)
        {
            var request = context.Message;

            // Deduct funds from the sender's account
            await _accountService.DeductFunds(request.SenderAccountNumber, request.Amount);

            await _bus.Publish<FundsDeductedMessage>(
                new FundsDeductedMessage(request.SenderAccountNumber,
                request.RecipientAccountNumber,
                request.Amount));
        }
    }
}
