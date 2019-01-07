using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Domain.Entititeis
{
    public class Fluid
        : Entity
    {
        /// <summary>
        /// Name of the <see cref="Fluid"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of <see cref="Component"/> using this
        /// <see cref="Fluid"/>.
        /// </summary>
        public List<Component> Components { get; set; }
    }
}
