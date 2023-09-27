using BankingApp.Application.Abstract.Repositories;
using BankingApp.Core.UserAggregate;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously. -> Sample task, no I/O DB operations :(

namespace BankingApp.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
	private static readonly List<User> Users = new();

	public async Task<IReadOnlyList<User>> GetAllUsersAsync()
	{
		return Users;
	}

	public async Task<User?> GetAsync(Guid id)
	{
		return Users.SingleOrDefault(u => u.Id == id);
	}

	public async Task AddAsync(User user)
	{
		Users.Add(user);
	}
}