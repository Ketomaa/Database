using System;
using System.Collections.Generic;
using System.Text;
using Bankdb.Models;
using Bankdb.Data;

namespace Bankdb.Repositories
{
    public interface IAccountRepository
    {
        void Create(Account account);
        Account ReadById(long id);
        List<Account> ReadAllAccounts();
        void Update(long id, Account account);
        void Delete(long id);
    }
}