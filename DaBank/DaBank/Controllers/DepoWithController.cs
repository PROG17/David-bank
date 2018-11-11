using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaBank.Models;
using DaBank.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DaBank.Controllers
{
    public class DepoWithController : Controller
    {

        private readonly IBankRepository _repository;

        public DepoWithController(IBankRepository repository)
        {
            _repository = repository;
        }

        public IActionResult DepoWith(string error)
        {
            if (error != null)
            {
                ViewBag.Error = error;
            }
            return View();
        }

        public IActionResult Transaction(string submitButton, decimal value, int account)
        {
            var bankController = new BankController();

            var requestedAccount = _repository.GetAccount(account);

            var bank = _repository.GetBank();

            if (requestedAccount != null)
            {
                switch (submitButton)
                {
                    case "Deposit":
                        var updateAcc = bankController.Deposit(requestedAccount, value);
                        bank.Customers.SelectMany(x => x.Account.Where(y => y.AccountNumber == account)).FirstOrDefault().Moneyz = updateAcc.Moneyz;
                        _repository.SaveBank(bank);
                        return View(updateAcc);
                    case "Withdraw":
                        var result = bankController.Withdraw(requestedAccount, value);
                        if (result != null)
                        {
                            bank.Customers.SelectMany(x => x.Account.Where(y => y.AccountNumber == account)).FirstOrDefault().Moneyz = result.Moneyz;
                            _repository.SaveBank(bank);
                            return View(result);
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