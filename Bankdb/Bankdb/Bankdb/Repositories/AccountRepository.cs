﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bankdb.Models;
using Bankdb.Data;
using Microsoft.EntityFrameworkCore;

namespace Bankdb.Repositories
{
    class AccountRepository : IAccountRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();
        public void Create(Account account)
        {
            _bankdbContext.Account.Add(account);
            _bankdbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        internal object ReadById(long id)
        {
            var account = _bankdbContext.Account
                .Include(a => a.BankId)
                .Where(a => a.BankId == id)
                .FirstOrDefault();
            return account;
        }

        internal object ReadAccountById(long id)
        {
            var account = _bankdbContext.Account
                .Include(a => a.CustomerId)
                .Where(a => a.CustomerId == id)
                .FirstOrDefault();
            return account;
        }

        public Account ReadAccountsByBankId(long id)
        {
            var account = _bankdbContext.Account
                .Include(a => a.BankId)
                .Where(a => a.BankId == id)
                .FirstOrDefault();
            return account;
        }

        public List<Account> ReadAllAccounts()
        {
            var accounts = _bankdbContext.Account
                .ToList();
            return accounts;
        }

        public void CreateTransaction(Transaction transaction)
        {
            _bankdbContext.Transaction.Add(transaction);
            var account = ReadAccountByIBAN(transaction.Iban);
            account.Balance += transaction.Amount;
            _bankdbContext.Account.Update(account);
            _bankdbContext.SaveChanges();
        }

        public Account ReadAccountByIBAN(string iban)
        {
            var account = _bankdbContext.Account
                .FirstOrDefault(a => a.Iban == iban);
            return account;
        }

        public void Update(long id, Account account)
        {
            throw new NotImplementedException();
        }

        Account IAccountRepository.ReadById(long id)
        {
            throw new NotImplementedException();
        }

        internal object ReadAccountsByBankId()
        {
            throw new NotImplementedException();
        }


    }
}
