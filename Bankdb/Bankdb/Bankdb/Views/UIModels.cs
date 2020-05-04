using System;
using System.Collections.Generic;
using System.Text;
using Bankdb.Models;
using Bankdb.Repositories;

namespace Bankdb.Views
{
    class UIModels
    {
        private readonly BankRepository _bankRepository = new BankRepository();
        private readonly CustomerRepository _customerRepository = new CustomerRepository();
        private readonly AccountRepository _accountRepository = new AccountRepository();
        private readonly TransactionRepository _transactionRepository = new TransactionRepository();

        public void CreateBank()
        {
            Bank bank = new Bank();
            bank.Name = "Uusi pankki X";
            bank.Bic = "5846389";
            Console.WriteLine("Uusi pankki luotu");
            _bankRepository.Create(bank);
        }

        public void CreateCustomerAccount()
        {
            Customer customer = new Customer();

            customer.BankId = 48;
            customer.Firstname = "Liisa";
            customer.Lastname = "Uosukainen";
            customer.Account = new List<Account>
            {
                new Account
                {
                    Balance = 1000,
                    Name = "Juomakassa",
                    Iban = "8694",
                    BankId = 1
                }
            };
            _customerRepository.Create(customer);
        }

        internal void ReadCustomerByBankId(long bankId)
        {
            var customers = _customerRepository.ReadAllCustomers();
            if (customers == null)
            {
                Console.WriteLine($"Pankkia ID: {bankId} ei löytynyt");
            }
            else
            {
                Console.WriteLine("Pankin asiakkaat:");
                foreach (var c in customers)
                {
                    if (c.BankId == bankId)
                    {
                        Console.WriteLine($"Asiakas Id: {c.Id}    {c.Firstname} {c.Lastname}");
                    }
                }
            }
        }

        internal void ReadAccountsByBankId(long bankId)
        {
            var accounts = _accountRepository.ReadAllAccounts();
            Console.WriteLine("Pankin tilit:");
            foreach (var a in accounts)
            {
                if (accounts == null)
                {
                    Console.WriteLine("Ei tilejä");
                }
                else if (a.BankId == bankId)
                {
                    Console.WriteLine($"Tili: {a.Name}\nBalance: {a.Balance}");
                }
            }
        }

        internal void ReadTransactionById(long id)
        {
            var transactions = _transactionRepository.ReadTransactions();

            foreach (var t in transactions)
            {
                if (transactions == null)
                {
                    Console.WriteLine("Ei löytynyt");
                }
                else
                {
                    Console.WriteLine($"Määrä: {t.Amount}\nAika: {t.TimeStamp}");
                }
            }
        }

        public void DeleteBank(long id)
        {
            ReadBankById(id);
            _bankRepository.Delete(id);
            ReadBankById(id);
        }

        public void ReadBankById(long id)
        {
            var bank = _bankRepository.ReadById(id);
            if (bank == null)
            {
                Console.WriteLine($"Pankki Id {id} ei löydy");
            }
            else
            {
                Console.WriteLine($"{bank.Id}   {bank.Name}");
            }
        }

        public void UpdateBank()
        {
            Bank updateBank = _bankRepository.ReadById(9);
            updateBank.Name = "Päivitetty pankki tiedot";
            updateBank.Bic = "89";
            _bankRepository.Update(7, updateBank);
        }

        public void UpdateCustomer()
        {
            Customer updateCustomer = _customerRepository.ReadById(25);
            updateCustomer.Firstname = "Jukka";
            updateCustomer.Lastname = "Kotipelto";
            updateCustomer.BankId = 4;

            _customerRepository.Update(25, updateCustomer);
        }

        public void DeleteCustomer(long id)
        {
            ReadCustomerById(id);
            _customerRepository.Delete(id);
            ReadCustomerById(id);
        }

        public void ReadCustomerById(long id)
        {
            var customer = _customerRepository.ReadById(id);
            if (customer == null)
            {
                Console.WriteLine($"Henkilöä Id {id} ei löydy");
            }
            else
            {
                Console.WriteLine($"Henkilö poistettu: {customer.Id}    {customer.Firstname} {customer.Lastname}");
            }
        }
    }
}
