using BankAccount.Domain.ContextCurrentAccount.Entities;
using BankAccount.Domain.ContextCurrentAccount.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.InfraStructure
{
	public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext _context;

        public AccountRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(Account bankAccount)
        {
            _context.BankAccounts.Add(bankAccount);

            _context.SaveChanges();
            UpdateOrCreateTransaction(bankAccount);
        }

        public async Task<IEnumerable<Account>> FindAll()
        {
			var result = _context.BankAccounts
                        .Include(x => x.Transaction).ToList();

            foreach (Account bankaccount in result)
            {
                if (bankaccount.Transaction != null)
                {
                    foreach (Transaction trs in bankaccount.Transaction)
                    {
                        trs.BankAccount = null;
                    }
                }
            }
            return await Task.FromResult(result);
        }

        public async Task<Account> FindBy(Guid AccountId)
        {
            var result= _context.BankAccounts
                        .Include(y => y.Transaction)
                        .FirstOrDefault(x => x.BankAccountId == AccountId);

            return await Task.FromResult(result);
        }

        public void Save(Account bankAccount)
        {
            Account account = _context.BankAccounts.FirstOrDefault(x => x.BankAccountId == bankAccount.BankAccountId);
            account.CustomerRef = bankAccount.CustomerRef;
            account.Balance = bankAccount.Balance;
            _context.SaveChanges();
            UpdateOrCreateTransaction(bankAccount);
        }

		private void UpdateOrCreateTransaction(Account bankAccount)
        {
            Account account = _context.BankAccounts.FirstOrDefault(x => x.BankAccountId == bankAccount.BankAccountId);
            
            var currentTrans = _context.Transactions.Where(x => x.BankAccount.BankAccountId == bankAccount.BankAccountId).ToList();
            
            foreach (Transaction trs in currentTrans)
            {
                _context.Transactions.Remove(trs);
                _context.SaveChanges();

            }

            foreach (Transaction trs in bankAccount.Transaction)
            {
                _context.Transactions.Add(trs);
                _context.SaveChanges();

            }



        }

    }
}
