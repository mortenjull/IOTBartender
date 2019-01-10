using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Application.Models
{
    public class ProcessOrderResponseModel
    {
        /// <summary>
        /// Id of the order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Status of the order.
        /// </summary>
        public int Status { get; set; }
    }
}
