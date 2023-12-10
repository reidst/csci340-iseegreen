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

        public static void Initialize(ISeeGreenContext context)
        {
            using SqliteConnection connection = new($"Data Source={Directory.GetCurrentDirectory()}/wwwroot/seed.db");
            connection.Open();
            
            if (!context.Categories.Any())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Categories;";
                List<Categories> categories = new();
                using SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(new Categories
                    {
                        Category = DbCast<string>(reader["Category"]),
                        Description = DbCast<string?>(reader["Description"]),
                        Sort = (int)DbCast<long>(reader["Sort"]),
                        APG4sort = DbCast<long>(reader["APG4sort"]),
                    });
                }
                context.Categories.AddRange(categories.ToArray());
                context.SaveChanges();
            }

            if (!context.TaxonomicOrders.Any())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TaxonomicOrders;";
                List<TaxonomicOrders> taxonomicOrders = new();
                using SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
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
                context.TaxonomicOrders.AddRange(taxonomicOrders.ToArray());
                context.SaveChanges();
            }

            if (!context.Families.Any())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Families;";
                List<Families> families = new();
                using SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    families.Add(new Families
                    {
                        Family = DbCast<string>(reader["Family"]),
                        TranslateTo = DbCast<string?>(reader["TranslateTo"]),
                        CategoryID = DbCast<string?>(reader["CategoryID"]),
                        TaxonomicOrderID = DbCast<string?>(reader["TaxonomicOrderID"]),
                    });
                }
                context.Families.AddRange(families.ToArray());
                context.SaveChanges();
            }

            if (!context.Genera.Any())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Genera;";
                List<Genera> genera = new();
                using SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    genera.Add(new Genera
                    {
                        KewID = DbCast<string>(reader["KewID"]),
                        GenusID = DbCast<string>(reader["GenusID"]),
                        FamilyID = DbCast<string?>(reader["FamilyID"]),
                    });
                }
                context.Genera.AddRange(genera.ToArray());
                context.SaveChanges();
            }

            if (!context.Taxa.Any())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Taxa;";
                List<Taxa> taxa = new();
                using SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
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
                context.Taxa.AddRange(taxa.ToArray());
                context.SaveChanges();
            }

            if (!context.Synonyms.Any())
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Synonyms;";
                List<Synonyms> synonyms = new();
                using SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
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
                context.Synonyms.AddRange(synonyms.ToArray());
                context.SaveChanges();
            }
        }
    }
}