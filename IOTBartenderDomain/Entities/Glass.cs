using System;
using System.Collections.Generic;
using System.Text;

namespace IOTBartenderDomain.Entities
{
    public class Glass
    {        
        public int Id { get; set; }
        public Enum Size { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
    }

    public enum GlassSize
    {
        Small,
        Medium,
        Large
    }
}
