using ASP.NET_Lab.Database;
using ASP.NET_Lab.Entities;
using ASP.NET_Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Lab.Controllers
{
    [ApiController]
    [Route("api/formcontroller")]
    public class FormController : ControllerBase
    {
        private readonly ExchangesDbContext _dbContext;

        public FormController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public AddNewItemResponseModel Post(ItemModel item)
        {
            var entity = new ItemEntity
            {
                Name = item.Name,
                Description = item.Description,
                IsVisible = item.IsVisible,
            };

            _dbContext.Items.Add(entity);
            _dbContext.SaveChanges();

            var items = _dbContext.Items.ToArray<ItemEntity>();

            return new AddNewItemResponseModel
            {
                Message = $"Your item {item.Name} was added.",
                Items = items,
                Success = true
            };
        }
    }
}
