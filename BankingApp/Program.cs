// See https://aka.ms/new-console-template for more information
using BankingApp;
using MassTransit;
using System;

Console.WriteLine("Hello, World!");


TransferRequest request = new TransferRequest();
request.SenderAccountNumber = "Sender1";
request.RecipientAccountNumber = "Recipient2";
request.Amount = 100;

var busControl = Bus.Factory.CreateUsingInMemory(cfg =>
{
});

busControl.ConnectReceiveEndpoint("transfer-requested", e =>
{
    IAccountService accountService = new AccountService(new AccountRepository());
    var deductConsumer = new DeductFundsConsumer(accountService, busControl);
    e.Consumer(() => deductConsumer);

    IAccountService accountService1 = new AccountService(new AccountRepository());
    var creditConsumer = new CreditFundsConsumer(accountService1, busControl);
    e.Consumer(() => creditConsumer);
});

//"funds - deducted"
//busControl.ConnectReceiveEndpoint("transfer-requested", e =>
//{
//    IAccountService accountService = new AccountService(new AccountRepository());
//    var creditConsumer = new CreditFundsConsumer(accountService, busControl);
//    e.Consumer(() => creditConsumer);
//});

busControl.Start();

ITransferService transferService = new TransferService(busControl);
var task = transferService.InitiateTransfer(request);


Console.ReadKey();

