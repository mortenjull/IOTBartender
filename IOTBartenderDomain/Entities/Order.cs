using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartenderDomain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        /// <summary>
        /// Id of the glass which the order is creaed for.
        /// </summary>
        public int GlassId { get; set; }

        /// <summary>
        /// Glass which the order is created for.
        /// </summary>
        public Glass Glass { get; set; }
        
        /// <summary>
        /// Id of the recipe.
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        /// Recipe for the order.
        /// </summary>
        public Recipe Recipe { get; set; }
    }
}
