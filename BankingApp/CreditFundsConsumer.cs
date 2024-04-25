using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class CreditFundsConsumer : IConsumer<FundsDeductedMessage>
    {
        private readonly IAccountService _accountService;
        private readonly IBus _bus;

        public CreditFundsConsumer(IAccountService accountService,
            IBus bus)
        {
            _accountService = accountService;
            _bus = bus;
        }

        public async Task Consume(ConsumeContext<FundsDeductedMessage> context)
        {
            var request = context.Message;

            try
            {
                await _accountService.CreditFunds(request.RecipientAccountNumber, request.Amount);

                await _bus.Publish<FundsCreditedMessage>(new FundsCreditedMessage(                
                    request.SenderAccountNumber,
                    request.RecipientAccountNumber,
                    request.Amount
                ));
            }
            catch (Exception ex)
            {
                await _bus.Publish<CreditFailedMessage>(new CreditFailedMessage(
                    request.SenderAccountNumber,
                    request.RecipientAccountNumber,
                    request.Amount,
                    ex.Message));
            }
        }
    }
}
