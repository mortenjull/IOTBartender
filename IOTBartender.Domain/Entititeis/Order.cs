using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Domain.Entititeis
{
    public class Order
        : Entity
    {
        /// <summary>
        /// <see cref="Recipe"/> for this order.
        /// </summary>
        public Recipe Recipe { get; set; }

        /// <summary>
        /// Status of the order.
        /// </summary>
        public OrderStatus Status { get; set; } = OrderStatus.Submitted;

        public enum OrderStatus
        {
            Submitted,
            Pending,
            Completed
        }
    }
}
