using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartender.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IOTBartender.Controllers
{
    [Route("[controller]/[action]")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrdersController(ApplicationDbContext applicationDbContext)
        {
            if (applicationDbContext == null)
                throw new ArgumentNullException(nameof(applicationDbContext));

            _applicationDbContext = applicationDbContext;
        }
    
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetOrders()
        {
            // Get all orders including glass, recipes etc.
            var orders = _applicationDbContext.Orders
                .Include(x => x.Recipe)
                .Include(x => x.Recipe.Components)
                .Include(x => x.Glass)
                .ToList();

            return new OkObjectResult(orders);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateOrder()
        {
            //Code for saving to db and for sending order to pie.
            return null;
        }


    }
}