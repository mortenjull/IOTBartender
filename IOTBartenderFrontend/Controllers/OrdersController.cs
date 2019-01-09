using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IOTBartenderFrontend.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Orders/{id}/Details")]
        public IActionResult Details(int id)
        {
            return View(id);
        }
    }
}