using BankAccount.Domain.ContextCurrentAccount.Entities;
using Microsoft.EntityFrameworkCore;


namespace BankAccount.InfraStructure
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options) { }
		public DbSet<Account> BankAccounts { get; set; }
		public DbSet<Transaction> Transactions { get; set; }

	}
}
