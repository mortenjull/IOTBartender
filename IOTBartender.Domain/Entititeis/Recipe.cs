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
        /// List of <see cref="Order"/> which is using this
        /// <see cref="Recipe"/>.
        /// </summary>
        public List<Order> Orders { get; set; }
    }
}
