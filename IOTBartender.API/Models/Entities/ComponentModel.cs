using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTBartender.API.Models.Entities
{
    public class ComponentModel
    {
        /// <summary>
        /// Id of the component.
        /// </summary>
        public int Id { get; set; }

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
