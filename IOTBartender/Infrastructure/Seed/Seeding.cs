using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartenderDomain.Entities;

namespace IOTBartender.Infrastructure.Seed
{
    public class Seeding
    {
        public static void Seed(ApplicationDbContext applicationDbContext)
        {
            // Component one setup.
            var componentOne = new Component()
            {
                Dozes = 1,
                Name = ComponentName.One
            };

            // Create recipe with one component.
            var recipeOne = new Recipe()
            {
                Components = new List<Component>()
                {
                    componentOne
                },
            };

            // Create classs.
            var glass = new Glass()
            {
                Recipe = recipeOne,
                Size = GlassSize.Small
            };

            // Add class, recipes and components to the database.
            applicationDbContext.Glasses.Add(glass);

            applicationDbContext.SaveChanges();
        }
    }
}
