using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartender.Application.Models
{
    public class ProcessDiagnosticModel
    {
        /// <summary>
        /// Time of the <see cref="Diagnostic"/>.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Cpu usage.
        /// </summary>
        public double Cpu { get; set; }

        /// <summary>
        /// Memory usage.
        /// </summary>
        public double Memory { get; set; }
    }
}
