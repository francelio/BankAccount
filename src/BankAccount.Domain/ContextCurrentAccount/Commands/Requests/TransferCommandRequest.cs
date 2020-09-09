using BankAccount.Domain.ContextCurrentAccount.Commands.Responses;
using MediatR;
using System;

namespace BankAccount.Domain.ContextCurrentAccount.Commands.Requests
{
	public class TransferCommandRequest : IRequest<TransferCommandResponse>
    {
        public Guid AccountIdTo { get; set; }
        public Guid AccountIdFrom { get; set; }
        public decimal Amount { get; set; }
    }
}