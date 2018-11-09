using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DaBank.Controllers
{
    public class DepoWithController : Controller
    {
        public IActionResult DepoWith()
        {
            return View();
        }
    }
}