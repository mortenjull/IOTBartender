using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartenderDomain.Entities
{
    public class Glass
    {        
        public int Id { get; set; }

        /// <summary>
        /// List of orders which are queue up for this class.
        /// </summary>
        public List<Order> Orders { get; set; }
    }

    public enum GlassSize
    {
        Small,
        Medium,
        Large
    }
}
