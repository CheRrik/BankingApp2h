namespace BankingApp.Core.UserAggregate;

public class User : Entity, IAggregateRoot
{
	private List<Account> _accounts = new List<Account>();

	public User(string firstName, string lastName)
	{
		FirstName = firstName;
		LastName = lastName;
	}

	public string FirstName { get; private set; }
	public string LastName { get; private set; }

	public IReadOnlyList<Account> Accounts => _accounts;

	public void Deposit(string accountNumber, decimal sum)
	{
		var account = _accounts.SingleOrDefault(a => a.AccountNo == accountNumber);
		if (account is null)
		{
			// TODO Domain ex
			throw new InvalidOperationException($"Domain: User {this.Id} has no account with number {accountNumber}");
		}

		account.Deposit(sum);
	}

	public void Withdraw(string accountNumber, decimal sum)
	{
		var account = _accounts.SingleOrDefault(a => a.AccountNo == accountNumber);
		if (account is null)
		{
			// TODO Domain ex
			throw new InvalidOperationException($"Domain: User {this.Id} has no account with number {accountNumber}");
		}

		account.Withdraw(sum);
	}

	public void AddAccount(Account account)
	{
		_accounts.Add(account);
	}

	public void RemoveAccount(string accountNumber)
	{
		var account = _accounts.SingleOrDefault(a => a.AccountNo == accountNumber);
		if (account is null)
		{
			// TODO Domain ex
			throw new InvalidOperationException($"Domain: User {this.Id} has no account with number {accountNumber}");
		}

		_accounts.Remove(account);
	}
}