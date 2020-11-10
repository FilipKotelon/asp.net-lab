using ASP.NET_Lab.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Lab.Models;

namespace ASP.NET_Lab.Controllers
{
    public class ExchangesController : Controller
    {
        [ServiceFilter(typeof(MyCustomActionFilter))]
        public IActionResult Show(string id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ItemModel item)
        {
            // TODO add to database

            var viewModel = new AddNewItemConfirmationViewModel
            {
                Id = 1,
                Name = item.Name,
            };

            //return View("AddConfirmation", viewModel);
            return RedirectToAction("AddConfirmation");
        }

        [HttpGet]
        public IActionResult AddConfirmation()
        {
            return View();
        }
    }
}
