using System.ComponentModel.DataAnnotations;

namespace csci340_iseegreen.Models
{
    public class Taxa
    {
        [Key]
        [StringLength(255)]
        public string kew_id { get; set; }
        [StringLength(255)]
        public string family { get; set; }
        [StringLength(255)]
        public Genera genus { get; set; }
        [StringLength(255)]
        public string SpecificEpithet { get; set; }
        [StringLength(255)]
        public string InfraspecificEpithet { get; set; }
        [StringLength(255)]
        public string TaxonRank { get; set; }
        [StringLength(255)]
        public string HybridGenus { get; set; }
        [StringLength(255)]
        public string HybridSpecies { get; set; }
        [StringLength(255)]
        public string Authors { get; set; }
        [StringLength(255)]
        public string USDAsymbol { get; set; }
        [StringLength(255)]
        public string USDAsynonym { get; set; }
    }
}