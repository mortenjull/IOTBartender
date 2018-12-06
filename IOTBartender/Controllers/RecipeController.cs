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
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RecipeController(ApplicationDbContext applicationDbContext)
        {
            if (applicationDbContext == null)
                throw new ArgumentNullException(nameof(applicationDbContext));

            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetRecipies()
        {
            var recipies = _applicationDbContext.Recipes.
                            Include(x => x.Components).                            
                            Include(x => x.Name).
                            Include(x => x.Id);

            return new OkObjectResult(recipies);
        }
    }
}