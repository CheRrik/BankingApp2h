using BankingApp.Application.Abstract.Repositories;
using MediatR;

namespace BankingApp.Application.Account.Commands;

public class AddAccountCommand : IRequest<Core.UserAggregate.Account>
{
	public AddAccountCommand(Guid userId)
	{
		UserId = userId;
	}

	public Guid UserId { get; set; }
}

public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand, Core.UserAggregate.Account>
{
	private readonly IUserRepository _userRepository;

	public AddAccountCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<Core.UserAggregate.Account> Handle(AddAccountCommand request, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetAsync(request.UserId);
		if (user is null)
		{
			throw new Exception("UserNotFound");
		}

		var account = new Core.UserAggregate.Account();
		user.AddAccount(account);

		// _UoW.SaveChangesAsync(ct);
		
		return account;
	}
}