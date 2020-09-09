using BankAccount.Domain.ContextCurrentAccount.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Domain.ContextCurrentAccount.Repositories
{
	public interface IAccountRepository
    {
        void Add(Account bankAccount);
        void Save(Account bankAccount);
        Task<IEnumerable<Account>> FindAll();
        Task<Account> FindBy(Guid AccountId);
    }
}