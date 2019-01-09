using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTBartender.API.Models.Entities
{
    public class OrderEventModel
    {
        /// <summary>
        /// Id of the order event.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Status of the event.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Time of the event.
        /// </summary>
        public DateTime Time { get; set; }
    }
}
