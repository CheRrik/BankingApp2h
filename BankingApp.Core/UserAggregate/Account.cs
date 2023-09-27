namespace BankingApp.Core.UserAggregate;

public class Account : Entity
{
	private static readonly Random Random = new();

	public Account()
	{
		AccountNo = string.Join("", Enumerable.Range(0, 12).Select(_ => Random.Next(0, 9)));
	}

	public string AccountNo { get; set; }

	// TODO make it a value obj with {balance, currency}
	public decimal Balance { get; set; }

	public AccountLimits AccountLimits { get; set; } = AccountLimits.Default;

	public void Deposit(decimal sum)
	{
		CanDeposit(sum);
		Balance += sum;
	}

	public void Withdraw(decimal sum)
	{
		CanWithdraw(sum);
		Balance -= sum;
	}

	private void CanWithdraw(decimal sum)
	{
		// An account cannot have less than $100 at any time in an account.
		var expectedBalanceAfterTransaction = Balance - sum;
		if (expectedBalanceAfterTransaction < AccountLimits.MinBalance)
		{
			throw new InvalidOperationException("An account cannot have less than $100 at any time in an account.");
		}

		// A user cannot withdraw more than 90% of their total balance from an account in a single transaction.
		var maxWithdrawal = Balance * AccountLimits.MaxWithdrawPerTranPercentage;
		if (sum > maxWithdrawal)
		{
			throw new InvalidOperationException("A user cannot withdraw more than 90% of their total balance from an account in a single transaction.");
		}
	}

	private void CanDeposit(decimal sum)
	{
		// A user cannot deposit more than $10,000 in a single transaction.
		if (sum > AccountLimits.MaxDepositPerTransaction)
		{
			throw new InvalidOperationException("A user cannot deposit more than $10,000 in a single transaction.");
		}
	}
}

public class AccountLimits
{
	public string LineName { get; set; }

	public decimal MinBalance { get; set; }

	public decimal MaxDepositPerTransaction { get; set; }

	public decimal MaxWithdrawPerTranPercentage { get; set; }

	public static AccountLimits Default = new()
	{
		LineName = "DefaultAccount",
		MaxDepositPerTransaction = 10000,
		MaxWithdrawPerTranPercentage = 0.9m,
		MinBalance = 100
	};
}