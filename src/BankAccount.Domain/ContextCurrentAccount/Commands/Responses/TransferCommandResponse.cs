using System;

namespace BankAccount.Domain.ContextCurrentAccount.Commands.Responses
{
	public class TransferCommandResponse
    {
        public Guid AccountIdTo { get; set; }
        public decimal BalanceAccountTo { get; set; }
        public Guid AccountIdFrom { get; set; }
        public decimal BalanceAccountFrom { get; set; }
    }
}