using BankingApp.Application.Abstract.Repositories;
using BankingApp.Core.UserAggregate;
using MediatR;

namespace BankingApp.Application.Users.Queries;

public class GetAllUsersQuery : IRequest<IReadOnlyList<User>>
{
}

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IReadOnlyList<User>>
{
	private readonly IUserRepository _userRepository;

	public GetAllUsersQueryHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public Task<IReadOnlyList<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
	{
		return _userRepository.GetAllUsersAsync();
	}
}