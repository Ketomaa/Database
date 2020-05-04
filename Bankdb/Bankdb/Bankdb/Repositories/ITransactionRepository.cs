using System;
using System.Collections.Generic;
using System.Text;
using Bankdb.Models;
using Bankdb.Data;

namespace Bankdb.Repositories
{
    public interface ITransactionRepository
    {
        void Create(Transaction transaction);
        List<Transaction> ReadTransactions();
        Transaction ReadById(long id);
        void Update(long id, Transaction transaction);
        void Delete(long id);
    }
}