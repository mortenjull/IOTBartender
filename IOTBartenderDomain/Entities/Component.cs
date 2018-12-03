using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartenderDomain.Entities
{
    public class Component
    {
        public int Id { get; set; }

        public Enum Name { get; set; }

        public int Dozes { get; set; }

        public Recipe Recipe { get; set; }
    }

    public enum ComponentName
    {
        One,
        Two,
        Three
    }
}
