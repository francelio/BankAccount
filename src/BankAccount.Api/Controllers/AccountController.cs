using System.Threading.Tasks;
using BankAccount.Domain.ContextCurrentAccount.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BankAccount.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Efetua o deposito na conta especificada
        /// </summary>
        /// <param name="Command">Informações da conta para deposito </param>
        /// <returns>Conta e saldo</returns>
        [HttpPost, Route("Deposit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Deposit([FromBody] DepositCommandRequest Command)
        {
            var commandResult = await _mediator.Send(Command);
            return Ok(commandResult);
        }

        /// <summary>
        /// Efetua a transferencia de uma conta para a outra
        /// </summary>
        /// <param name="Command">Informações da conta de origem e destino </param>
        /// <returns>Conta e saldo</returns>
        [HttpPost, Route("Transfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Transfer([FromBody] TransferCommandRequest Command)
        {
            var commandResult = await _mediator.Send(Command);
            return Ok(commandResult);
        }

        /// <summary>
        /// Retorna todas as contas cadastradas
        /// </summary>
        /// <returns>Retorna a lista de constas cadastradas</returns>
        [HttpGet,Route("AllCurrentAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllCurrentAccounts()
        {
            var Command = new CurrentCommandRequest();
            var commandResult = await _mediator.Send(Command);
            return Ok(commandResult);
        }
    }
}
