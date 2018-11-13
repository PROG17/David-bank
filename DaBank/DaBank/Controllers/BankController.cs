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

        public bool Transfer(Account from, Account to, decimal amount)
        {
            if (Withdraw(from, amount) != null)
                Deposit(to, amount);
            else
                return false;

            return true;
        }
    }
}