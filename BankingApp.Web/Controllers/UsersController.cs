using BankingApp.Application.Users.Commands;
using BankingApp.Application.Users.Queries;
using BankingApp.Core.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Web.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
	private readonly IMediator _mediator;

	public UsersController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<User>>> GetAll(CancellationToken ct)
	{
		var users = await _mediator.Send(new GetAllUsersQuery(), ct);

		return Ok(users);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<User>> GetAll(Guid id, CancellationToken ct)
	{
		var user = await _mediator.Send(new GetUserQuery(id), ct);
		if (user is null)
		{
			return NotFound();
		}

		return Ok(user);
	}

	[HttpPost]
	public async Task<ActionResult<User>> Create(AddUserCommand addUserCommand, CancellationToken ct)
	{
		var user = await _mediator.Send(addUserCommand, ct);
		
		// TODO build URL
		return Created("TODO Build URL", user);
	}
}