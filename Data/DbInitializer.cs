using csci340_iseegreen.Models;
using Microsoft.Data.Sqlite;

namespace csci340_iseegreen.Data
{
    public static class DbInitializer
    {
        // https://stackoverflow.com/a/870771
        private static T? DbCast<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default;
            }
            else
            {
                return (T)obj;
            }
        }

        public static async Task InitializeAsync(WebApplication app)
        {
            Console.WriteLine("[DebugLog][DbInitializer] Creating service scope...");
            using var scope = app.Services.CreateScope();
            Console.WriteLine("[DebugLog][DbInitializer] Getting ISeeGreenContext service...");
            ISeeGreenContext context = scope.ServiceProvider.GetRequiredService<ISeeGreenContext>();
            Console.WriteLine("[DebugLog][DbInitializer] Context retrieved.");

            string seedDbPath = $"{Directory.GetCurrentDirectory()}/wwwroot/seed.db";
            Console.WriteLine($"[DebugLog][DbInitializer] seedDbPath='{seedDbPath}'");
            using SqliteConnection connection = new($"Data Source={seedDbPath}");
            Console.WriteLine("[DebugLog][DbInitializer] connecting to SQLite seed database...");
            await connection.OpenAsync();
            Console.WriteLine("[DebugLog][DbInitializer] Connection opened.");

            if (!context.Categories.Any())
            {
                Console.WriteLine("[DebugLog][DbInitializer] Table 'Categories' is empty, adding seed data...");
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Categories;";
                List<Categories> categories = new();
                Console.WriteLine("[DebugLog][DbInitializer] Executing SELECT command...");
                using SqliteDataReader reader = await command.ExecuteReaderAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Reading data...");
                while (await reader.ReadAsync())
                {
                    categories.Add(new Categories
                    {
                        Category = DbCast<string>(reader["Category"]),
                        Description = DbCast<string?>(reader["Description"]),
                        Sort = (int)DbCast<long>(reader["Sort"]),
                        APG4sort = DbCast<long>(reader["APG4sort"]),
                    });
                }
                Console.WriteLine($"[DebugLog][DbInitializer] Adding {categories.Count} new Categories to the context...");
                await context.Categories.AddRangeAsync(categories.ToArray());
                Console.WriteLine("[DebugLog][DbInitializer] Saving changes...");
                await context.SaveChangesAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Changes saved.");
            }

            if (!context.TaxonomicOrders.Any())
            {
                Console.WriteLine("[DebugLog][DbInitializer] Table 'TaxonomicOrders' is empty, adding seed data...");
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TaxonomicOrders;";
                List<TaxonomicOrders> taxonomicOrders = new();
                Console.WriteLine("[DebugLog][DbInitializer] Executing SELECT command...");
                using SqliteDataReader reader = await command.ExecuteReaderAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Reading data...");
                while (await reader.ReadAsync())
                {
                    taxonomicOrders.Add(new TaxonomicOrders
                    {
                        TaxonomicOrder = DbCast<string>(reader["TaxonomicOrder"]),
                        SortLevel1Heading = DbCast<string?>(reader["SortLevel1Heading"]),
                        SortLevel1 = (int)DbCast<long>(reader["SortLevel1"]),
                        SortLevel2Heading = DbCast<string?>(reader["SortLevel2Heading"]),
                        SortLevel2 = (int)DbCast<long>(reader["SortLevel2"]),
                        SortLevel3Heading = DbCast<string?>(reader["SortLevel3Heading"]),
                        SortLevel3 = (int)DbCast<long>(reader["SortLevel3"]),
                        SortLevel4Heading = DbCast<string?>(reader["SortLevel4Heading"]),
                        SortLevel4 = (int)DbCast<long>(reader["SortLevel4"]),
                        SortLevel5Heading = DbCast<string?>(reader["SortLevel5Heading"]),
                        SortLevel5 = (int)DbCast<long>(reader["SortLevel5"]),
                        SortLevel6Heading = DbCast<string?>(reader["SortLevel6Heading"]),
                        SortLevel6 = (int)DbCast<long>(reader["SortLevel6"]),
                    });
                }
                Console.WriteLine($"[DebugLog][DbInitializer] Adding {taxonomicOrders.Count} new TaxonomicOrders to the context...");
                await context.TaxonomicOrders.AddRangeAsync(taxonomicOrders.ToArray());
                Console.WriteLine("[DebugLog][DbInitializer] Saving changes...");
                await context.SaveChangesAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Changes saved.");
            }

            if (!context.Families.Any())
            {
                Console.WriteLine("[DebugLog][DbInitializer] Table 'Families' is empty, adding seed data...");
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Families;";
                List<Families> families = new();
                Console.WriteLine("[DebugLog][DbInitializer] Executing SELECT command...");
                using SqliteDataReader reader = await command.ExecuteReaderAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Reading data...");
                while (await reader.ReadAsync())
                {
                    families.Add(new Families
                    {
                        Family = DbCast<string>(reader["Family"]),
                        TranslateTo = DbCast<string?>(reader["TranslateTo"]),
                        CategoryID = DbCast<string?>(reader["CategoryID"]),
                        TaxonomicOrderID = DbCast<string?>(reader["TaxonomicOrderID"]),
                    });
                }
                Console.WriteLine($"[DebugLog][DbInitializer] Adding {families.Count} new Families to the context...");
                await context.Families.AddRangeAsync(families.ToArray());
                Console.WriteLine("[DebugLog][DbInitializer] Saving changes...");
                await context.SaveChangesAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Changes saved.");
            }

            if (!context.Genera.Any())
            {
                Console.WriteLine("[DebugLog][DbInitializer] Table 'Genera' is empty, adding seed data...");
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Genera;";
                List<Genera> genera = new();
                Console.WriteLine("[DebugLog][DbInitializer] Executing SELECT command...");
                using SqliteDataReader reader = await command.ExecuteReaderAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Reading data...");
                while (await reader.ReadAsync())
                {
                    genera.Add(new Genera
                    {
                        KewID = DbCast<string>(reader["KewID"]),
                        GenusID = DbCast<string>(reader["GenusID"]),
                        FamilyID = DbCast<string?>(reader["FamilyID"]),
                    });
                }
                Console.WriteLine($"[DebugLog][DbInitializer] Adding {genera.Count} new Genera to the context...");
                await context.Genera.AddRangeAsync(genera.ToArray());
                Console.WriteLine("[DebugLog][DbInitializer] Saving changes...");
                await context.SaveChangesAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Changes saved.");
            }

            if (!context.Taxa.Any())
            {
                Console.WriteLine("[DebugLog][DbInitializer] Table 'Taxa' is empty, adding seed data...");
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Taxa;";
                List<Taxa> taxa = new();
                Console.WriteLine("[DebugLog][DbInitializer] Executing SELECT command...");
                using SqliteDataReader reader = await command.ExecuteReaderAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Reading data...");
                while (await reader.ReadAsync())
                {
                    taxa.Add(new Taxa
                    {
                        KewID = DbCast<string>(reader["KewID"]),
                        GenusID = DbCast<string?>(reader["GenusID"]),
                        SpecificEpithet = DbCast<string?>(reader["SpecificEpithet"]),
                        InfraspecificEpithet = DbCast<string?>(reader["InfraspecificEpithet"]),
                        TaxonRank = DbCast<string?>(reader["TaxonRank"]),
                        HybridGenus = DbCast<string?>(reader["HybridGenus"]),
                        HybridSpecies = DbCast<string?>(reader["HybridSpecies"]),
                        Authors = DbCast<string?>(reader["Authors"]),
                        USDAsymbol = DbCast<string?>(reader["USDAsymbol"]),
                        USDAsynonym = DbCast<string?>(reader["USDAsynonym"]),
                    });
                }
                Console.WriteLine($"[DebugLog][DbInitializer] Adding {taxa.Count} new Taxa to the context...");
                await context.Taxa.AddRangeAsync(taxa.ToArray());
                Console.WriteLine("[DebugLog][DbInitializer] Saving changes...");
                await context.SaveChangesAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Changes saved.");
            }

            if (!context.Synonyms.Any())
            {
                Console.WriteLine("[DebugLog][DbInitializer] Table 'Synonyms' is empty, adding seed data...");
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Synonyms;";
                List<Synonyms> synonyms = new();
                Console.WriteLine("[DebugLog][DbInitializer] Executing SELECT command...");
                using SqliteDataReader reader = await command.ExecuteReaderAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Reading data...");
                while (await reader.ReadAsync())
                {
                    synonyms.Add(new Synonyms
                    {
                        KewID = DbCast<string>(reader["KewID"]),
                        TaxaID = DbCast<string?>(reader["TaxaID"]),
                        Genus = DbCast<string?>(reader["Genus"]),
                        Species = DbCast<string?>(reader["Species"]),
                        InfraspecificEpithet = DbCast<string?>(reader["InfraspecificEpithet"]),
                        TaxonRank = DbCast<string?>(reader["TaxonRank"]),
                        Authors = DbCast<string?>(reader["Authors"]),
                    });
                }
                Console.WriteLine($"[DebugLog][DbInitializer] Adding {synonyms.Count} new Synonyms to the context...");
                await context.Synonyms.AddRangeAsync(synonyms.ToArray());
                Console.WriteLine("[DebugLog][DbInitializer] Saving changes...");
                await context.SaveChangesAsync();
                Console.WriteLine("[DebugLog][DbInitializer] Changes saved.");
            }
            Console.WriteLine("[DebugLog][DbInitializer] Successfully seeded database.");
        }
    }
}