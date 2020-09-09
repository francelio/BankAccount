using BankAccount.Api.Controllers;
using BankAccount.Domain.ContextCurrentAccount.Commands.Requests;
using BankAccount.Domain.ContextCurrentAccount.Commands.Responses;
using MediatR;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace BankAccount.Test
{
	public class ControllerTest
    {
        private readonly Mock<IMediator> Mediator;
        public ControllerTest()
        {
            Mediator = new Mock<IMediator>();
        }

        [Fact]
        public void MakeDeposit_Success_Result()
        {
            var makeDepositRequest = new DepositCommandRequest(Guid.Parse("0a6dc873-21a5-42a4-a5e8-4a78a05ea059"), 111.2M);
            Mediator.Setup(x => x.Send(It.IsAny<DepositCommandRequest>(), new CancellationToken())).
                ReturnsAsync(new DepositCommandResponse() { AccountIdTo = Guid.Parse("0a6dc873-21a5-42a4-a5e8-4a78a05ea059"), Balance= 121.2M });

           
            var depositController = new AccountController(Mediator.Object);

            //Action
            var result = depositController.Deposit(makeDepositRequest);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void MakeTransf_Success_Result()
        {
            var makeTransfRequest = new TransferCommandRequest() { AccountIdTo=Guid.Parse("0a6dc873-21a5-42a4-a5e8-4a78a05ea059"), AccountIdFrom = Guid.Parse("f9fb6c56-e340-47be-92d5-a1ab7d3985db"),Amount= 111.2M };
            Mediator.Setup(x => x.Send(It.IsAny<TransferCommandRequest>(), new CancellationToken())).
                ReturnsAsync(new TransferCommandResponse() { AccountIdTo = Guid.Parse("0a6dc873-21a5-42a4-a5e8-4a78a05ea059"), AccountIdFrom = Guid.Parse("f9fb6c56-e340-47be-92d5-a1ab7d3985db"), BalanceAccountFrom = 121.2M, BalanceAccountTo=90.9M });


            var orderController = new AccountController(Mediator.Object);

            //Action
            var result = orderController.Transfer(makeTransfRequest);

            //Assert
            Assert.NotNull(result);
        }

    }
}