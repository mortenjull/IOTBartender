using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Domain.Entititeis
{
    public class Order
        : Entity
    {
        /// <summary>
        /// If of recipe.
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        /// <see cref="Recipe"/> for this order.
        /// </summary>
        public Recipe Recipe { get; set; }

        /// <summary>
        /// Status of the order.
        /// </summary>
        public OrderStatus Status { get; set; } = OrderStatus.Submitted;

        /// <summary>
        /// Time of the order.
        /// </summary>
        public DateTime Time { get; set; }

        public enum OrderStatus
        {
            Submitted,
            Pending,
            Completed
        }
    }
}
