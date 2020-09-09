using System;

namespace BankAccount.Domain.ContextCurrentAccount.Commands.Responses
{
	public class DepositCommandResponse
    {
        public Guid AccountIdTo { get; set; }
        public decimal Balance { get; set; }
    }
}