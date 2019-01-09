using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Domain.Entititeis
{
    public class OrderEvent
        : Entity
    {
        /// <summary>
        /// Id of the <see cref="Order"/> which the <see cref="OrderEvent"/> is attached to.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// <see cref="Order"/> which the <see cref="OrderEvent"/> is attached to.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Time of event.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Type of event.
        /// </summary>
        public OrderEventType Type { get; set; }

        public enum OrderEventType
        {
            Submitted,
            Pending,
            Executing,
            Completed,
            Failed
        }
    }
}
