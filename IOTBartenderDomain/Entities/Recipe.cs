using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartenderDomain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }

        /// <summary>
        /// Name of the Recipe/Drink.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of components in the recipe.
        /// </summary>
        public List<Component> Components { get; set; }

        // List of orders which the recipe is used in.
        public List<Order> Orders { get; set; }
    }
}
