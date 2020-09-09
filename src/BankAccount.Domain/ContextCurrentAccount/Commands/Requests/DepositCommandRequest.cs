using BankAccount.Domain.ContextCurrentAccount.Commands.Responses;
using MediatR;
using System;

namespace BankAccount.Domain.ContextCurrentAccount.Commands.Requests
{
	public class DepositCommandRequest : IRequest<DepositCommandResponse>
    {
		public DepositCommandRequest(Guid accountIdTo, decimal amount)
		{
			AccountIdTo = accountIdTo;
			Amount = amount;
		}

		public Guid AccountIdTo { get; set; }
        public decimal Amount { get; set; }

    }
}
