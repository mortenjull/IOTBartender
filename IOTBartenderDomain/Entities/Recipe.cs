using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartenderDomain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }

        public List<Component> Components { get; set; }

        public List<Glass> Glasses { get; set; }
    }
}
