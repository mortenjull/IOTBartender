using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTBartenderFrontend.Infrastructure.Gateways.Bartender.Models
{
    public class ComponentModel
    {
        /// <summary>
        /// Fluid in the component.
        /// </summary>
        public FluidModel Fluid { get; set; }

        /// <summary>
        /// Size of the component.
        /// </summary>
        public int Size { get; set; }
    }
}
