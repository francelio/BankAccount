using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.ContextCurrentAccount.Entities
{
    public class Transaction
    {
        public Transaction(decimal deposit, decimal withdrawal, string reference, DateTime date)
        {
            this.Deposit = deposit;
            this.Withdrawal = withdrawal;
            this.Reference = reference;
            this.Date = date;
        }
        [Key]
        public Guid TransactionId { get; set; }
        public decimal Deposit { get; set; }
        public decimal Withdrawal { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public Account BankAccount { get; set; }
    }
}
