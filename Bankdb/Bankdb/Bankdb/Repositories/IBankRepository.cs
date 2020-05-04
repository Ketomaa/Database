using System;
using System.Collections.Generic;
using System.Text;
using Bankdb.Models;
using Bankdb.Data;

namespace Bankdb.Repositories
{
    public interface IBankRepository
    {
        void Create(Bank bank);
        Bank ReadById(long id);
        void Update(long id, Bank bank);
        void Delete(long id);

    }
}