using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTBartenderFrontend.Models.Bartender.Models
{
    public class RecipeModel
    {
        public string Id{ get; set; }

        /// <summary>
        /// Name of the Recipe/Drink.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of components in the recipe.
        /// </summary>
        public List<ComponentModel> Components { get; set; }
               
    }
}
