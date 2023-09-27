using BankingApp.Application.Abstract.Repositories;
using MediatR;

namespace BankingApp.Application.Account.Queries;

public class GetUserAccountsQuery : IRequest<IEnumerable<Core.UserAggregate.Account>>
{
	public GetUserAccountsQuery(Guid userId)
	{
		UserId = userId;
	}

	public Guid UserId { get; set; }
}

public class GetUserAccountsQueryHandler : IRequestHandler<GetUserAccountsQuery, IEnumerable<Core.UserAggregate.Account>>
{
	private readonly IUserRepository _userRepository;

	public GetUserAccountsQueryHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<IEnumerable<Core.UserAggregate.Account>> Handle(GetUserAccountsQuery request, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetAsync(request.UserId);
		if (user is null)
		{
			// On a real proj I would handle it differently. By throwing a Domain ex. cuz we want to respond with 404 for such cases.
			// return Enumerable.Empty<Core.UserAggregate.Account>();
			throw new Exception("UserNotFound");
		}

		return user.Accounts;
	}
}