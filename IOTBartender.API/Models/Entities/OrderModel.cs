using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IOTBartender.Domain.Entititeis.Order;

namespace IOTBartender.API.Models.Entities
{
    public class OrderModel
    {
        /// <summary>
        /// Id of the order.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Status of the order.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Time of the order.
        /// </summary>
        public DateTime Time { get; set; }
    }
}
