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
                new TaxonomicOrders{TaxonomicOrder="Oxalidales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Eudicots", SortLevel2=4, SortLevel3Heading="Pentapetalae", SortLevel3=2, SortLevel4Heading="Superrosids", SortLevel4=1, SortLevel5Heading="Rosids", SortLevel5=1, SortLevel6Heading="Fabids", SortLevel6=1},
                new TaxonomicOrders{TaxonomicOrder="Cucurbitales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Eudicots", SortLevel2=4, SortLevel3Heading="Pentapetalae", SortLevel3=2, SortLevel4Heading="Superrosids", SortLevel4=1, SortLevel5Heading="Rosids", SortLevel5=1, SortLevel6Heading="Rosids", SortLevel6=1},
                new TaxonomicOrders{TaxonomicOrder="Zingiberales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Monocots", SortLevel2=2, SortLevel3Heading="Commelinids", SortLevel3=1},
                new TaxonomicOrders{TaxonomicOrder="Asterales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Eudicots", SortLevel2=4, SortLevel3Heading="Pentapetalae", SortLevel3=2, SortLevel4Heading="Superasterids", SortLevel4=2, SortLevel5Heading="Asterids", SortLevel5=1, SortLevel6Heading="Campanulids", SortLevel6=2},
                new TaxonomicOrders{TaxonomicOrder="Liliales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Monocots", SortLevel2=2},
                new TaxonomicOrders{TaxonomicOrder="Lamiales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Eudicots", SortLevel2=4, SortLevel3Heading="Pentapetalae", SortLevel3=2, SortLevel4Heading="Superasterids", SortLevel4=2, SortLevel5Heading="Asterids", SortLevel5=1, SortLevel6Heading="Lamiids", SortLevel6=1},
                new TaxonomicOrders{TaxonomicOrder="Gentianales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Eudicots", SortLevel2=4, SortLevel3Heading="Pentapetalae", SortLevel3=2, SortLevel4Heading="Superasterids", SortLevel4=2, SortLevel5Heading="Asterids", SortLevel5=1, SortLevel6Heading="Lamiids", SortLevel6=1},
                new TaxonomicOrders{TaxonomicOrder="Ericales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Eudicots", SortLevel2=4, SortLevel3Heading="Pentapetalae", SortLevel3=2, SortLevel4Heading="Superasterids", SortLevel4=2, SortLevel5Heading="Asterids", SortLevel5=1},
                new TaxonomicOrders{TaxonomicOrder="Poales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Monocots", SortLevel2=2, SortLevel3Heading="Commelinids", SortLevel3=1},
                new TaxonomicOrders{TaxonomicOrder="Brassicales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Eudicots", SortLevel2=4, SortLevel3Heading="Pentapetalae", SortLevel3=2, SortLevel4Heading="Superrosids", SortLevel4=1, SortLevel5Heading="Rosids", SortLevel5=1, SortLevel6Heading="Malvids", SortLevel6=2},
                new TaxonomicOrders{TaxonomicOrder="Rosales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Eudicots", SortLevel2=4, SortLevel3Heading="Pentapetalae", SortLevel3=2, SortLevel4Heading="Superrosids", SortLevel4=1, SortLevel5Heading="Rosids", SortLevel5=1, SortLevel6Heading="Rosids", SortLevel6=1},
                new TaxonomicOrders{TaxonomicOrder="Malvales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Eudicots", SortLevel2=4, SortLevel3Heading="Pentapetalae", SortLevel3=2, SortLevel4Heading="Superrosids", SortLevel4=1, SortLevel5Heading="Rosids", SortLevel5=1, SortLevel6Heading="Malvids", SortLevel6=2},
                new TaxonomicOrders{TaxonomicOrder="Asparagales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Monocots", SortLevel2=2},
                new TaxonomicOrders{TaxonomicOrder="Myrtales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Eudicots", SortLevel2=4, SortLevel3Heading="Pentapetalae", SortLevel3=2, SortLevel4Heading="Superrosids", SortLevel4=1, SortLevel5Heading="Rosids", SortLevel5=1, SortLevel6Heading="Malvids", SortLevel6=2},
                new TaxonomicOrders{TaxonomicOrder="Apiales", SortLevel1Heading="Angiosperms", SortLevel1=3, SortLevel2Heading="Eudicots", SortLevel2=4, SortLevel3Heading="Pentapetalae", SortLevel3=2, SortLevel4Heading="Superasterids", SortLevel4=2, SortLevel5Heading="Asterids", SortLevel5=1, SortLevel6Heading="Campanulids", SortLevel6=2},
            };

            context.TaxonomicOrders.AddRange(taxonomicOrders);
            context.SaveChanges();

            var families = new Families[]
            {
                new Families{Family="Apocynaceae", CategoryID="D", TaxonomicOrderID="Gentianales"},
                new Families{Family="Cucurbitaceae", CategoryID="D", TaxonomicOrderID="Cucurbitales"},
                new Families{Family="Ebenaceae", CategoryID="D", TaxonomicOrderID="Ericales"},
                new Families{Family="Campanulaceae", CategoryID="D", TaxonomicOrderID="Asterales"},
                new Families{Family="Melastomataceae", CategoryID="D", TaxonomicOrderID="Myrtales"},
                new Families{Family="Marantaceae", CategoryID="D", TaxonomicOrderID="Zingiberales"},
                new Families{Family="Elaeocarpaceae", CategoryID="D", TaxonomicOrderID="Oxalidales"},
                new Families{Family="Myrtaceae", CategoryID="D", TaxonomicOrderID="Myrtales"},
                new Families{Family="Rosaceae", CategoryID="D", TaxonomicOrderID="Rosales"},
                new Families{Family="Liliaceae", CategoryID="M", TaxonomicOrderID="Liliales"},
                new Families{Family="Orobanchaceae", CategoryID="D", TaxonomicOrderID="Lamiales"},
                new Families{Family="Iridaceae", CategoryID="M", TaxonomicOrderID="Asparagales"},
                new Families{Family="Asteraceae", CategoryID="D", TaxonomicOrderID="Asterales"},
                new Families{Family="Malvaceae", CategoryID="D", TaxonomicOrderID="Malvales"},
                new Families{Family="Brassicaceae", CategoryID="D", TaxonomicOrderID="Brassicales"},
                new Families{Family="Capparaceae", CategoryID="D", TaxonomicOrderID="Brassicales"},
                new Families{Family="Cyperaceae", CategoryID="M", TaxonomicOrderID="Poales"},
                new Families{Family="Apiaceae", CategoryID="D", TaxonomicOrderID="Apiales"},
            };

            context.Families.AddRange(families);
            context.SaveChanges();

            var genera = new Genera[]
            {
                new Genera{KewID="30001899-2", GenusID="Cirsium", FamilyID="Asteraceae"},
                new Genera{KewID="30396569-2", GenusID="Comolia", FamilyID="Melastomataceae"},
                new Genera{KewID="5976-1", GenusID="Morisonia", FamilyID="Capparaceae"},
                new Genera{KewID="330778-2", GenusID="Buchnera", FamilyID="Orobanchaceae"},
                new Genera{KewID="30003057-2", GenusID="Prunus", FamilyID="Rosaceae"},
                new Genera{KewID="30228531-2", GenusID="Trichosanthes", FamilyID="Cucurbitaceae"},
                new Genera{KewID="326017-2", GenusID="Diospyros", FamilyID="Ebenaceae"},
                new Genera{KewID="5652-1", GenusID="Clermontia", FamilyID="Campanulaceae"},
                new Genera{KewID="30000557-2", GenusID="Abutilon", FamilyID="Malvaceae"},
                new Genera{KewID="30001220-2", GenusID="Myrcia", FamilyID="Myrtaceae"},
                new Genera{KewID="30010004-2", GenusID="Vincetoxicum", FamilyID="Apocynaceae"},
                new Genera{KewID="30008840-2", GenusID="Fritillaria", FamilyID="Liliaceae"},
                new Genera{KewID="40118-1", GenusID="Hymenolaena", FamilyID="Apiaceae"},
                new Genera{KewID="60436436-2", GenusID="Braya", FamilyID="Brassicaceae"},
                new Genera{KewID="37370-1", GenusID="Thalia", FamilyID="Marantaceae"},
                new Genera{KewID="20339-1", GenusID="Geissorhiza", FamilyID="Iridaceae"},
                new Genera{KewID="331569-2", GenusID="Dontostemon", FamilyID="Brassicaceae"},
                new Genera{KewID="325904-2", GenusID="Senecio", FamilyID="Asteraceae"},
                new Genera{KewID="331197-2", GenusID="Fimbristylis", FamilyID="Cyperaceae"},
                new Genera{KewID="326026-2", GenusID="Elaeocarpus", FamilyID="Elaeocarpaceae"},
            };

            context.Genera.AddRange(genera);
            context.SaveChanges();

            var taxa = new Taxa[]
            {
                new Taxa{KewID="877048-1", GenusID="Cirsium", SpecificEpithet="acaule", InfraspecificEpithet="gregarium", TaxonRank="subsp.", Authors="(Boiss. ex DC.) Talavera"},
                new Taxa{KewID="567909-1", GenusID="Comolia", SpecificEpithet="latifolia", Authors="Cogn."},
                new Taxa{KewID="77168927-1", GenusID="Clermontia", SpecificEpithet="oblongifolia", InfraspecificEpithet="oblongifolia", TaxonRank="subsp."},
                new Taxa{KewID="323010-1", GenusID="Diospyros", SpecificEpithet="siamang", Authors="Bakh."},
                new Taxa{KewID="77107533-1", GenusID="Elaeocarpus", SpecificEpithet="dolichostylus", InfraspecificEpithet="chloranthus", TaxonRank="var.", Authors="(A.C.Sm.) Coode"},
                new Taxa{KewID="252139-2", GenusID="Thalia", SpecificEpithet="densibracteata", Authors="Petersen"},
                new Taxa{KewID="77176914-1", GenusID="Vincetoxicum", SpecificEpithet="ascyrifolium", Authors="Franch. & Sav."},
                new Taxa{KewID="60468198-2", GenusID="Braya", SpecificEpithet="stigmatosa", Authors="(Franch.) Al-Shehbaz & D.A.German"},
                new Taxa{KewID="915030-1", GenusID="Geissorhiza", SpecificEpithet="brevituba", Authors="(G.J.Lewis) Goldblatt"},
                new Taxa{KewID="77061686-1", GenusID="Senecio", SpecificEpithet="longipilus", Authors="I.Thomps."},
                new Taxa{KewID="77183715-1", GenusID="Morisonia", SpecificEpithet="ecuadorica", Authors="(Iltis) Christenh. & Byng"},
                new Taxa{KewID="77153252-1", GenusID="Myrcia", SpecificEpithet="parca", Authors="Sobral"},
                new Taxa{KewID="932481-1", GenusID="Hymenolaena", SpecificEpithet="polyphylla", Authors="Rech.f."},
                new Taxa{KewID="20001992-1", GenusID="Fritillaria", SpecificEpithet="baskilensis", Authors="Behcet"},
                new Taxa{KewID="210953-2", GenusID="Prunus", SpecificEpithet="zinggii", Authors="Standl."},
                new Taxa{KewID="799974-1", GenusID="Buchnera", SpecificEpithet="gracilis", Authors="R.Br."},
                new Taxa{KewID="308248-1", GenusID="Fimbristylis", SpecificEpithet="schultzii", Authors="Boeckeler"},
                new Taxa{KewID="1007754-1", GenusID="Trichosanthes", SpecificEpithet="emarginata", Authors="Rugayah"},
                new Taxa{KewID="1015475-1", GenusID="Dontostemon", SpecificEpithet="pinnatifidus", InfraspecificEpithet="linearifolius", TaxonRank="subsp.", Authors="(Maxim.) Al-Shehbaz & H.Ohba"},
                new Taxa{KewID="558365-1", GenusID="Abutilon", SpecificEpithet="menziesii", Authors="Seem.", USDAsymbol="ABME2"},
            };

            context.Taxa.AddRange(taxa);
            context.SaveChanges();

            var synonyms = new Synonyms[]
            {
                new Synonyms{KewID="436898-1", TaxaID="915030-1", Genus="Engysiphon", Species="brevitubus", Authors="G.J.Lewis"},
                new Synonyms{KewID="127339-3", TaxaID="308248-1", Genus="Fimbristylis", Species="platystachys", InfraspecificEpithet="schultzii", TaxonRank="var.", Authors="(Boeckeler) Domin"},
                new Synonyms{KewID="127379-3", TaxaID="308248-1", Genus="Fimbristylis", Species="platystachys", InfraspecificEpithet="typica", TaxonRank="var.", Authors="Domin"},
                new Synonyms{KewID="308172-1", TaxaID="308248-1", Genus="Fimbristylis", Species="platystachys", Authors="Boeckeler"},
                new Synonyms{KewID="308290-1", TaxaID="308248-1", Genus="Fimbristylis", Species="stellata", Authors="S.T.Blake"},
                new Synonyms{KewID="66488-3", TaxaID="308248-1", Genus="Iria", Species="platystachya", Authors="(Boeckeler) Kuntze"},
                new Synonyms{KewID="102646-1", TaxaID="77176914-1", Genus="Vincetoxicum", Species="acuminatum", Authors="C.Morren ex Decne."},
                new Synonyms{KewID="93885-1", TaxaID="77176914-1", Genus="Alexitoxicon", Species="acuminatum", Authors="Pobed."},
                new Synonyms{KewID="93998-1", TaxaID="77176914-1", Genus="Antitoxicum", Species="acuminatum", Authors="Pobed."},
                new Synonyms{KewID="95982-1", TaxaID="77176914-1", Genus="Cynanchum", Species="acuminatifolium", Authors="Hemsl."},
                new Synonyms{KewID="95987-1", TaxaID="77176914-1", Genus="Cynanchum", Species="acuminatum", Authors="(C.Morren ex Decne.) Matsum."},
                new Synonyms{KewID="96035-1", TaxaID="77176914-1", Genus="Cynanchum", Species="ascyrifolium", Authors="(Franch. & Sav.) Matsum."},
                new Synonyms{KewID="96082-1", TaxaID="77176914-1", Genus="Cynanchum", Species="calcareum", Authors="H.Ohashi"},
                new Synonyms{KewID="977926-1", TaxaID="77176914-1", Genus="Cynanchum", Species="ascyrifolium", InfraspecificEpithet="calcareum", TaxonRank="var.", Authors="(H.Ohashi) T.Yamaz."},
                new Synonyms{KewID="988911-1", TaxaID="77176914-1", Genus="Vincetoxicum", Species="calcareum", Authors="(H.Ohashi) Liede"},
                new Synonyms{KewID="566302-1", TaxaID="567909-1", Genus="Arthrostemma", Species="aubletii", Authors="DC."},
                new Synonyms{KewID="567898-1", TaxaID="567909-1", Genus="Comolia", Species="aubletii", Authors="Triana"},
                new Synonyms{KewID="575271-1", TaxaID="567909-1", Genus="Rhexia", Species="latifolia", Authors="Aubl."},
                new Synonyms{KewID="576120-1", TaxaID="567909-1", Genus="Tetrameris", Species="aubletii", Authors="Naudin"},
                new Synonyms{KewID="284183-1", TaxaID="60468198-2", Genus="Erysimum", Species="stigmatosum", Authors="Franch."},
                new Synonyms{KewID="285151-1", TaxaID="60468198-2", Genus="Hesperis", Species="piasezkii", Authors="(Maxim.) Kuntze"},
                new Synonyms{KewID="286785-1", TaxaID="60468198-2", Genus="Malcolmia", Species="perennans", Authors="Maxim."},
                new Synonyms{KewID="289639-1", TaxaID="60468198-2", Genus="Sisymbrium", Species="piasezkii", Authors="Maxim."},
                new Synonyms{KewID="290835-1", TaxaID="60468198-2", Genus="Torularia", Species="maximowiczii", Authors="Botsch."},
                new Synonyms{KewID="920371-1", TaxaID="60468198-2", Genus="Torularia", Species="humilis", InfraspecificEpithet="maximowiczii", TaxonRank="var.", Authors="(Botsch.) H.L.Yang"},
                new Synonyms{KewID="945595-1", TaxaID="60468198-2", Genus="Neotorularia", Species="maximowiczii", Authors="(Botsch.) Botsch."},
                new Synonyms{KewID="945596-1", TaxaID="60468198-2", Genus="Neotorularia", Species="piasezkii", Authors="(Maxim.) Botsch."},
                new Synonyms{KewID="44675-2", TaxaID="77183715-1", Genus="Capparis", Species="ecuadorica", Authors="Iltis"},
                new Synonyms{KewID="77096487-1", TaxaID="77183715-1", Genus="Cynophalla", Species="ecuadorica", Authors="(Iltis) Iltis & Cornejo"},
                new Synonyms{KewID="195419-1", TaxaID="877048-1", Genus="Cirsium", Species="gregarium", Authors="Willk."},
                new Synonyms{KewID="324033-1", TaxaID="77107533-1", Genus="Elaeocarpus", Species="chloranthus", Authors="A.C.Sm."},
                new Synonyms{KewID="324064-1", TaxaID="77107533-1", Genus="Elaeocarpus", Species="cuneifolius", Authors="Schltr."},
                new Synonyms{KewID="324425-1", TaxaID="77107533-1", Genus="Elaeocarpus", Species="ulapensis", Authors="Knuth"},
                new Synonyms{KewID="141714-1", TaxaID="77168927-1", Genus="Clermontia", Species="aspera", Authors="E.Wimm."},
                new Synonyms{KewID="252140-2", TaxaID="252139-2", Genus="Thalia", Species="densibracteata", InfraspecificEpithet="angustissima", TaxonRank="var.", Authors="Suess. & Beyerle"},
            };

            context.Synonyms.AddRange(synonyms);
            context.SaveChanges();
        }
    }
}