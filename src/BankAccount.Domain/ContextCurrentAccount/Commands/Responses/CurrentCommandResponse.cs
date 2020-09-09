using BankAccount.Domain.ContextCurrentAccount.Entities;
using System.Collections.Generic;

namespace BankAccount.Domain.ContextCurrentAccount.Commands.Responses
{
	public class CurrentCommandResponse
	{
		public IEnumerable<Account> Account { get; set; }
	}
}