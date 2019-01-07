using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Domain.Entititeis
{
    public class Component
        : Entity
    {
        /// <summary>
        /// Id of the <see cref="Fluid"/>.
        /// </summary>
        public int FluidId { get; set; }

        /// <summary>
        /// <see cref="Fluid"/> of the <see cref="Component"/>.
        /// </summary>
        public Fluid Fluid { get; set; }
    
        /// <summary>
        /// Id of the <see cref="Recipe"/> using this <see cref="Component"/>.
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        /// <see cref="Recipe"/> using this <see cref="Component"/>.
        /// </summary>
        public Recipe Recipe { get; set; }

        /// <summary>
        /// Name of sizes.
        /// </summary>
        public int Size { get; set; }
    }
}
