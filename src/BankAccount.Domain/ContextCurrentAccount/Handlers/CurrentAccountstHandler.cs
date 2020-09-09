using BankAccount.Domain.ContextCurrentAccount.Commands.Requests;
using BankAccount.Domain.ContextCurrentAccount.Commands.Responses;
using BankAccount.Domain.ContextCurrentAccount.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BankAccount.Domain.ContextCurrentAccount.Handlers
{
	public class CurrentHandler : IRequestHandler<CurrentCommandRequest, CurrentCommandResponse>
	{
		private readonly IAccountRepository _AccountRepository;
		public CurrentHandler(
			IAccountRepository AccountRepository)
		{
			_AccountRepository = AccountRepository;
		}

		public async Task<CurrentCommandResponse> Handle(CurrentCommandRequest request, CancellationToken cancellationToken)
		{
			var response = new CurrentCommandResponse
			{
				Account = await _AccountRepository.FindAll()
			};

			return await Task.FromResult(response);
		}
	}
}