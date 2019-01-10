using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Application.Models
{
    public class ProcessOrderRequestModel
    {
        /// <summary>
        /// Id of the order to process.
        /// </summary>
        public int OrderId { get; set;}

        /// <summary>
        /// List of components.
        /// </summary>
        public List<Component> Components { get; set; }

        public class Component
        {
            /// <summary>
            /// Id of the fluid to use.
            /// </summary>
            public int FluidId { get; set; }
            /// <summary>
            /// Size of the fluid.
            /// </summary>
            public int Size { get; set; }
        }
    }
}
