using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartenderDomain.Entities;
using IOTBartenderFrontend.Models;
using IOTBartenderFrontend.Models.Bartender.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;

namespace IOTBartenderFrontend.Controllers
{
    public class BartenderController : Controller
    {
        private OptionViewModel _optionViewModel;
        public BartenderController()
        {
            this._optionViewModel = new OptionViewModel();
            this._optionViewModel.Recipies = new List<RecipeModel>();

            var component1 = new ComponentModel();
            component1.Id = "1";
            component1.Dozes = "1";
            component1.Name = "DatGooodShit!";

            var component2 = new ComponentModel();
            component2.Id = "1";
            component2.Dozes = "1";
            component2.Name = "Gin";

            var component3 = new ComponentModel();
            component3.Id = "1";
            component3.Dozes = "1";
            component3.Name = "Rum";

            var recipe1 = new RecipeModel();
            recipe1.Id = "1";
            recipe1.Components = new List<ComponentModel>() { component1, component2, component3, component3 };
            recipe1.Name = "looong John!!";
            

            var recipe2 = new RecipeModel();
            recipe2.Components = new List<ComponentModel>() { component1, component2, component3, component1 };
            recipe2.Id = "2";
            recipe2.Name = "Looooonger John!";
            

            var recipe3 = new RecipeModel();
            recipe3.Components = new List<ComponentModel>() { component1, component2, component2, component3 };
            recipe3.Id = "3";
            recipe3.Name = "Fun for her and him!";
            

            var recipe4 = new RecipeModel();
            recipe4.Components = new List<ComponentModel>() { component1, component3, component2, component3 };
            recipe4.Id = "4";
            recipe4.Name = "One more please!";
            

            var recipe5 = new RecipeModel();
            recipe5.Components = new List<ComponentModel>() { component1, component2, component3, component1 };
            recipe5.Id = "5";
            recipe5.Name = "why is the floor upside down?";
            

            var recipe6 = new RecipeModel();
            recipe6.Components = new List<ComponentModel>() { component1, component2, component3, component2 };
            recipe6.Id = "6";
            recipe6.Name = "Generic piece drink of shit!!";
           

            this._optionViewModel.Recipies.Add(recipe1);
            this._optionViewModel.Recipies.Add(recipe2);
            this._optionViewModel.Recipies.Add(recipe3);
            this._optionViewModel.Recipies.Add(recipe4);
            this._optionViewModel.Recipies.Add(recipe5);
            this._optionViewModel.Recipies.Add(recipe6);
            this._optionViewModel.Recipies.Add(recipe6);
            this._optionViewModel.Recipies.Add(recipe6);
            this._optionViewModel.Recipies.Add(recipe6);
            this._optionViewModel.Recipies.Add(recipe6);
            this._optionViewModel.Recipies.Add(recipe6);
            this._optionViewModel.Recipies.Add(recipe6);
            this._optionViewModel.Recipies.Add(recipe6);
            this._optionViewModel.Recipies.Add(recipe6);


        }

        public IActionResult Index()
        {
            return View(this._optionViewModel);
        }

        public IActionResult OrderDrink(string id)
        {
            return RedirectToAction("Index", "Bartender");
        }
    }
}