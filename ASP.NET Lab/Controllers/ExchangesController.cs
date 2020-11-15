using ASP.NET_Lab.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Lab.Models;
using ASP.NET_Lab.Database;
using ASP.NET_Lab.Entities;

namespace ASP.NET_Lab.Controllers
{
    public class ExchangesController : Controller
    {
        private readonly ExchangesDbContext _dbContext;

        public ExchangesController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [ServiceFilter(typeof(MyCustomActionFilter))]
        public IActionResult Show(string id)
        {
            return View();
        }

        public IActionResult ShowItems()
        {
            var items = _dbContext.Items.ToArray<ItemEntity>();

            return View("ShowItems", items);
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
