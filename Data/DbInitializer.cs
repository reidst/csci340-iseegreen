using csci340_iseegreen.Models;
using System.Data.Odbc;

namespace csci340_iseegreen.Data
{
    public static class DbInitializer
    {
        // https://stackoverflow.com/a/870771
        private static T? ConvertFromDBVal<T>(object obj)
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

        public static void Initialize(ISeeGreenContext context, bool isDevelopment)
        {
            OdbcCommand command;
            OdbcDataReader reader;
            
            // help taken from https://iamsorush.com/posts/connect-access-db-net-core/
            string dbFilePath = isDevelopment
                ? $"{Directory.GetCurrentDirectory()}\\wwwroot\\ISG.accdb"
                : "/site/wwwroot/wwwroot/ISG.accdb";
            string accdbConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=" + dbFilePath;
            using OdbcConnection connection = new(accdbConnectionString);
            connection.Open();

            if (!context.Categories.Any())
            {
                command = new("SELECT * FROM Categories;", connection);
                reader = command.ExecuteReader();
                List<Categories> categories = new();
                while (reader.Read())
                {
                    categories.Add(new Categories
                    {
                        Category = ConvertFromDBVal<string>(reader["Category"]),
                        Description = ConvertFromDBVal<string?>(reader["Description"]),
                        Sort = ConvertFromDBVal<short>(reader["Sort"]),
                        APG4sort = ConvertFromDBVal<int>(reader["APG4sort"]),
                    });
                }
                context.Categories.AddRange(categories.ToArray());
                context.SaveChanges();
            }

            if (!context.TaxonomicOrders.Any())
            {
                command = new("SELECT * FROM TaxonomicOrders;", connection);
                reader = command.ExecuteReader();
                List<TaxonomicOrders> taxonomicOrders = new();
                while (reader.Read())
                {
                    taxonomicOrders.Add(new TaxonomicOrders
                    {
                        TaxonomicOrder = ConvertFromDBVal<string>(reader["TaxonomicOrder"]),
                        SortLevel1Heading = ConvertFromDBVal<string?>(reader["SortLevel1Heading"]),
                        SortLevel1 = ConvertFromDBVal<short>(reader["SortLevel1"]),
                        SortLevel2Heading = ConvertFromDBVal<string?>(reader["SortLevel2Heading"]),
                        SortLevel2 = ConvertFromDBVal<short>(reader["SortLevel2"]),
                        SortLevel3Heading = ConvertFromDBVal<string?>(reader["SortLevel3Heading"]),
                        SortLevel3 = ConvertFromDBVal<short>(reader["SortLevel3"]),
                        SortLevel4Heading = ConvertFromDBVal<string?>(reader["SortLevel4Heading"]),
                        SortLevel4 = ConvertFromDBVal<short>(reader["SortLevel4"]),
                        SortLevel5Heading = ConvertFromDBVal<string?>(reader["SortLevel5Heading"]),
                        SortLevel5 = ConvertFromDBVal<short>(reader["SortLevel5"]),
                        SortLevel6Heading = ConvertFromDBVal<string?>(reader["SortLevel6Heading"]),
                        SortLevel6 = ConvertFromDBVal<short>(reader["SortLevel6"]),
                    });
                }
                context.TaxonomicOrders.AddRange(taxonomicOrders.ToArray());
                context.SaveChanges();
            }

            if (!context.Families.Any())
            {
                command = new("SELECT * FROM Families;", connection);
                reader = command.ExecuteReader();
                List<Families> families = new();
                while (reader.Read())
                {
                    families.Add(new Families
                    {
                        Family = ConvertFromDBVal<string>(reader["Family"]),
                        TranslateTo = ConvertFromDBVal<string?>(reader["TranslateTo"]),
                        CategoryID = ConvertFromDBVal<string?>(reader["Category"]),
                        TaxonomicOrderID = ConvertFromDBVal<string?>(reader["TaxonomicOrder"]),
                    });
                }
                context.Families.AddRange(families.ToArray());
                context.SaveChanges();
            }

            if (!context.Genera.Any())
            {
                command = new("SELECT * FROM Genera;", connection);
                reader = command.ExecuteReader();
                List<Genera> genera = new();
                while (reader.Read())
                {
                    genera.Add(new Genera
                    {
                        KewID = ConvertFromDBVal<string>(reader["kew_id"]),
                        GenusID = ConvertFromDBVal<string>(reader["genus"]),
                        FamilyID = ConvertFromDBVal<string?>(reader["family"]),
                    });
                }
                context.Genera.AddRange(genera.ToArray());
                context.SaveChanges();
            }

            if (!context.Taxa.Any())
            {
                command = new("SELECT * FROM Taxa;", connection);
                reader = command.ExecuteReader();
                List<Taxa> taxa = new();
                while (reader.Read())
                {
                    taxa.Add(new Taxa
                    {
                        KewID = ConvertFromDBVal<string>(reader["kew_id"]),
                        GenusID = ConvertFromDBVal<string?>(reader["genus"]),
                        SpecificEpithet = ConvertFromDBVal<string?>(reader["SpecificEpithet"]),
                        InfraspecificEpithet = ConvertFromDBVal<string?>(reader["InfraspecificEpithet"]),
                        TaxonRank = ConvertFromDBVal<string?>(reader["TaxonRank"]),
                        HybridGenus = ConvertFromDBVal<string?>(reader["HybridGenus"]),
                        HybridSpecies = ConvertFromDBVal<string?>(reader["HybridSpecies"]),
                        Authors = ConvertFromDBVal<string?>(reader["Authors"]),
                        USDAsymbol = ConvertFromDBVal<string?>(reader["USDAsymbol"]),
                        USDAsynonym = ConvertFromDBVal<string?>(reader["USDAsynonym"]),
                    });
                }
                context.Taxa.AddRange(taxa.ToArray());
                context.SaveChanges();
            }

            if (!context.Synonyms.Any())
            {
                command = new("SELECT * FROM Synonyms;", connection);
                reader = command.ExecuteReader();
                List<Synonyms> synonyms = new();
                while (reader.Read())
                {
                    synonyms.Add(new Synonyms
                    {
                        KewID = ConvertFromDBVal<string>(reader["kew_id"]),
                        TaxaID = ConvertFromDBVal<string?>(reader["accepted_kew_id"]),
                        Genus = ConvertFromDBVal<string?>(reader["genus"]),
                        Species = ConvertFromDBVal<string?>(reader["species"]),
                        InfraspecificEpithet = ConvertFromDBVal<string?>(reader["InfraspecificEpithet"]),
                        TaxonRank = ConvertFromDBVal<string?>(reader["TaxonRank"]),
                        Authors = ConvertFromDBVal<string?>(reader["Authors"]),
                    });
                }
                context.Synonyms.AddRange(synonyms.ToArray());
                context.SaveChanges();
            }
        }
    }
}