using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DaBank.Models;

namespace DaBank.Controllers
{
    public class HomeController : Controller
    {
        public ViewModel model = new ViewModel();

        public HomeController()
        {
            var bankController = new BankController();

            model.bank = bankController.CreateBankRep();
        }

        public IActionResult Index()
        {        
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
