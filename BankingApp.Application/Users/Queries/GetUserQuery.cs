using BankingApp.Application.Abstract.Repositories;
using BankingApp.Core.UserAggregate;
using MediatR;

namespace BankingApp.Application.Users.Queries;

public class GetUserQuery : IRequest<User?>
{
	public GetUserQuery(Guid id)
	{
		Id = id;
	}

	public Guid Id { get; set; }
}

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User?>
{
	private readonly IUserRepository _userRepository;

	public GetUserQueryHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken)
	{
		return _userRepository.GetAsync(request.Id);
	}
}