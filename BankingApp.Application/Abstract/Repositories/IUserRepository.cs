using BankingApp.Core.UserAggregate;

namespace BankingApp.Application.Abstract.Repositories;

public interface IUserRepository
{
	Task<IReadOnlyList<User>> GetAllUsersAsync();
	Task<User?> GetAsync(Guid id);
	Task AddAsync(User user);
}