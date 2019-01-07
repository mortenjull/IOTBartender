using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Domain.Entititeis
{
    public class Recipe
        : Entity
    {
        /// <summary>
        /// List of <see cref="Component"/> in recipe.
        /// </summary>
        public List<Component> Components { get; set; }

        /// <summary>
        /// Id of the <see cref="Recipe"/> of the <see cref="Component"/>.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// <see cref="Recipe"/> of the <see cref="Component"/>.
        /// </summary>
        public Order Order { get; set; }
    }
}
