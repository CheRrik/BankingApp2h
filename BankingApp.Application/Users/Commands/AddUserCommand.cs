using BankingApp.Application.Abstract.Repositories;
using BankingApp.Core.UserAggregate;
using MediatR;

namespace BankingApp.Application.Users.Commands;

public class AddUserCommand : IRequest<User>
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
}

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
{
	private readonly IUserRepository _userRepository;

	public AddUserCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
	{
		var user = new User(request.FirstName, request.LastName);
		await _userRepository.AddAsync(user);

		return user;
	}
}