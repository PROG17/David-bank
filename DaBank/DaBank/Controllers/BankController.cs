using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaBank.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public Account Withdraw(Account acc, decimal value)
        {
            if (acc.Moneyz < value)
            {
                return null;
            }
            else
            {
                acc.Moneyz -= value;
            }

            return acc;
        }

        public Account Deposit(Account acc, decimal value)
        {
            acc.Moneyz += value;

            return acc;
        }

        public BankRepository CreateBankRep()
        {
            var bankRep = new BankRepository();

            bankRep.Customers = new List<Customer>
            {
                new Customer("David Agdelius", 1, new List<Account>
                {
                    new Account(10, 10000),
                    new Account(11, 400)
                }),
                new Customer("Thorleif Svensson", 2, new List<Account>
                {
                    new Account(222, 5000)
                }),
                new Customer("Ronny Karlsson", 3, new List<Account>
                {
                    new Account(34, 5000000)
                }),
                new Customer("Eskil Knutsson", 4, new List<Account>
                {
                    new Account(21, 100)
                })
            };

            return bankRep;
        }
    }
}