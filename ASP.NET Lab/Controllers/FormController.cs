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
        [HttpPost]
        public AddNewItemResponseModel Post(ItemModel item)
        {
            return new AddNewItemResponseModel
            {
                Message = $"Your item {item.Name} was added",
                Success = true
            };
        }
    }
}
