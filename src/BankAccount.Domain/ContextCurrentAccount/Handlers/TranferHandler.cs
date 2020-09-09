using BankAccount.Domain.ContextCurrentAccount.Commands.Requests;
using BankAccount.Domain.ContextCurrentAccount.Commands.Responses;
using BankAccount.Domain.ContextCurrentAccount.Entities;
using BankAccount.Domain.ContextCurrentAccount.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BankAccount.Domain.ContextCurrentAccount.Handlers
{
	public class TransferHandler : IRequestHandler<TransferCommandRequest, TransferCommandResponse>
	{
		private readonly IAccountRepository _AccountRepository;
		public TransferHandler(IAccountRepository AccountRepository)
		{
			_AccountRepository = AccountRepository;
		}

		public async Task<TransferCommandResponse> Handle(TransferCommandRequest request, CancellationToken cancellationToken)
		{
			var response = new TransferCommandResponse();

			Account bankAccountTo = await _AccountRepository.FindBy(request.AccountIdTo);
			Account bankAccountFrom = await _AccountRepository.FindBy(request.AccountIdFrom);

			if (bankAccountFrom.CanWithdraw(request.Amount))
			{
				bankAccountFrom.Withdraw(request.Amount, "Transfer To cc " + bankAccountTo.CustomerRef + " ");
				bankAccountTo.Deposit(request.Amount, "From Acc " + bankAccountFrom.CustomerRef + " ");
				
				_AccountRepository.Save(bankAccountTo);
				_AccountRepository.Save(bankAccountFrom);

				response.AccountIdFrom = bankAccountFrom.BankAccountId;
				response.BalanceAccountFrom = bankAccountFrom.Balance;
				response.AccountIdTo = bankAccountTo.BankAccountId;
				response.BalanceAccountTo = bankAccountTo.Balance;
			}
			else
			{
				//  throw new InsufficientFundsException();
			}

			return await Task.FromResult(response);
		}


	}


}
