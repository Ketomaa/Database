using System;
using System.Collections.Generic;
using System.Text;
using Bankdb.Models;
using Bankdb.Data;

namespace Bankdb.Repositories
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        Customer ReadById(long id);
        List<Customer> ReadAllCustomers();
        void Update(long id, Customer customer);
        void Delete(long id);
    }
}