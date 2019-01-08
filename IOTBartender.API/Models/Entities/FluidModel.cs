using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTBartender.API.Models.Entities
{
    public class FluidModel
    {
        /// <summary>
        /// Id of the Fluid.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the fluid.
        /// </summary>
        public string Name { get; set; }
    }
}
