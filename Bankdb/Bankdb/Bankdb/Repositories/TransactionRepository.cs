﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bankdb.Models;
using Bankdb.Data;
using Microsoft.EntityFrameworkCore;

namespace Bankdb.Repositories
{
    class TransactionRepository : ITransactionRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void Create(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Transaction ReadById(long id)
        {
            var transaction = _bankdbContext.Transaction
                .Include(t => t.Amount)
                .Where(t => t.Id == id).
                FirstOrDefault();
            return transaction;
        }

        public List<Transaction> ReadTransactions()
        {
            var transactions = _bankdbContext.Transaction
                .ToList();
            return transactions;
        }

        public void Update(long id, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}