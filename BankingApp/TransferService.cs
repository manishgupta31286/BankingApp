using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public interface ITransferService
    {
        Task InitiateTransfer(TransferRequest request);
    }

    public class TransferService : ITransferService
    {
        private readonly IBus _bus;

        public TransferService(IBus bus)
        {
            _bus = bus;
        }

        public async Task InitiateTransfer(TransferRequest request)
        {
            var message = new TransferRequestMessage(request.SenderAccountNumber, request.RecipientAccountNumber, request.Amount);

            // Publish transfer request message to message bus
            await _bus.Publish<TransferRequestMessage>(message);
        }
    }
}
