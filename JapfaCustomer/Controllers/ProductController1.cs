using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JapfaCustomer.Controllers
{
    public class ProductController1 : Controller
    {
        public IActionResult ProductGet()
        {
            TempData["data"] = "I'm temprory data to used in subsequent request";
            return View();
        }
    }
}
