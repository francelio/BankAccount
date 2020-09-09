using BankAccount.Domain.ContextCurrentAccount.Commands.Responses;
using MediatR;

namespace BankAccount.Domain.ContextCurrentAccount.Commands.Requests
{
	public class CurrentCommandRequest : IRequest<CurrentCommandResponse>
    {
    }
}