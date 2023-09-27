using BankingApp.Application.Account.Commands;
using BankingApp.Application.Account.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Web.Controllers;

[ApiController]
[Route("users/{userId}/accounts")]
public class UserAccountsController : ControllerBase
{
	private readonly IMediator _mediator;

	public UserAccountsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<ActionResult> Get(Guid userId, CancellationToken ct)
	{
		var accounts = await _mediator.Send(new GetUserAccountsQuery(userId), ct);

		return Ok(accounts);
	}
	
	[HttpPost]
	public async Task<ActionResult> Create(Guid userId, CancellationToken ct)
	{
		var account = await _mediator.Send(new AddAccountCommand(userId), ct);

		return Ok(account);
	}
}