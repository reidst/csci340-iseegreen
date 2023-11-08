using csci340_iseegreen.Models;

namespace csci340_iseegreen.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ISeeGreenContext context)
        {
            // Look for any students.
            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Categories[]
            {
                new Categories{Category="D", Description="Dicot", Sort=5, APG4sort=4},
                new Categories{Category="F", Description="Fern", Sort=1, APG4sort=1},
                new Categories{Category="G", Description="Gymnosperm", Sort=3, APG4sort=3},
                new Categories{Category="L", Description="Lycophyte", Sort=2, APG4sort=2},
                new Categories{Category="M", Description="Monocot", Sort=4, APG4sort=4},
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var taxonomicOrders = new TaxonomicOrders[]
            {
            };

            context.TaxonomicOrders.AddRange(taxonomicOrders);
            context.SaveChanges();

            var families = new Families[]
            {
            };

            context.Families.AddRange(families);
            context.SaveChanges();

            var genera = new Genera[]
            {
            };

            context.Genera.AddRange(genera);
            context.SaveChanges();

            var taxa = new Taxa[]
            {
            };

            context.Taxa.AddRange(taxa);
            context.SaveChanges();

            var synonyms = new Synonyms[]
            {
            };

            context.Synonyms.AddRange(synonyms);
            context.SaveChanges();
        }
    }
}