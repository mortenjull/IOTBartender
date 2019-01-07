using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Domain.Entititeis
{
    public class Order
        : Entity
    {
        /// <summary>
        /// List of <see cref="Recipe"/> using this
        /// <see cref="Order"/>.
        /// </summary>
        public List<Recipe> Recipies { get; set; }
    }
}
