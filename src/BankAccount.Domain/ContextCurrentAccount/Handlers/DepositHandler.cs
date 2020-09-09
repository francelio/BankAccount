using BankAccount.Domain.ContextCurrentAccount.Commands.Requests;
using BankAccount.Domain.ContextCurrentAccount.Commands.Responses;
using BankAccount.Domain.ContextCurrentAccount.Entities;
using BankAccount.Domain.ContextCurrentAccount.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BankAccount.Domain.ContextCurrentAccount.Handlers
{
	public class DepositHandler : IRequestHandler<DepositCommandRequest, DepositCommandResponse>
	{
		private readonly IAccountRepository _AccountRepository;
		public DepositHandler(
			IAccountRepository AccountRepository)
		{
			_AccountRepository = AccountRepository;
		}

		public async Task<DepositCommandResponse> Handle(DepositCommandRequest request, CancellationToken cancellationToken)
		{
			var response = new DepositCommandResponse();

			Account bankAccountTo = await _AccountRepository.FindBy(request.AccountIdTo);

			if (bankAccountTo!=null)
			{
				bankAccountTo.Deposit(request.Amount, "Deposit");
				_AccountRepository.Save(bankAccountTo);

				response.AccountIdTo= bankAccountTo.BankAccountId;
				response.Balance = request.Amount + bankAccountTo.Balance;
			}
			else
			{
				//  throw new AccountNotFoundException();
			}

			return await Task.FromResult(response);
		}


	}


}
