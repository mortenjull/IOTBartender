using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTBartender.API.Models.Entities
{
    public class RecipeModel
    {
        /// <summary>
        /// Id of the recipe.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the component.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of components in the recipe.
        /// </summary>
        public List<ComponentModel> Components { get; set; }
    }
}
