using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DaBank.Models;
using DaBank.Repository;

namespace DaBank.Controllers
{
    public class HomeController : Controller
    {
        public ViewModel model = new ViewModel();

        private readonly IBankRepository _repository;
        public HomeController(IBankRepository repository)
        {
            _repository = repository;
        }


        public IActionResult Index()
        {

            model.Customers = _repository.GetBank().Customers;

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
