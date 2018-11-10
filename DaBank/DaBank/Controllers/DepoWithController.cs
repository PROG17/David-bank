using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaBank.Controllers
{
    public class DepoWithController : Controller
    {
        public IActionResult DepoWith(string error)
        {
            if(error != null)
            {
                ViewBag.Error = error;
            }
            return View();
        }

        public IActionResult Transaction(string submitButton, decimal value, int account)
        {
            var bankController = new BankController();

            var requestedAccount = bankController.CreateBankRep().Customers.SelectMany(x=> x.Account.Where(y=> y.AccountNumber == account)).FirstOrDefault();

            if (requestedAccount != null)
            {
                switch (submitButton)
                {
                    case "Deposit":                        
                        return (View(bankController.Deposit(requestedAccount, value)));
                    case "Withdraw":
                        var result = bankController.Withdraw(requestedAccount, value);
                        if(result != null)
                        {
                            return (View(result));
                        }
                        return RedirectToAction("DepoWith", new { error = "Not enough balance to withdraw." });
                    default:

                        return RedirectToAction("DepoWith");
                }
            }

            return RedirectToAction("DepoWith");

        }

    }
}