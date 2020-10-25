using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Lab.Controllers
{
    public class ExchangesController : Controller
    {
        public IActionResult Show()
        {
            return View();
        }
    }
}
