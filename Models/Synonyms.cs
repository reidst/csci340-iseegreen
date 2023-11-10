using System.ComponentModel.DataAnnotations;

namespace csci340_iseegreen.Models
{
    public class Synonyms
    {
        [Key]
        [StringLength(255)]
        public required string KewID { get; set; }
        [StringLength(255)]
        public string? TaxaID { get; set; }
        [StringLength(255)]
        public string? Genus { get; set; }
        [StringLength(255)]
        public string? Species { get; set; }
        [StringLength(255)]
        public string? InfraspecificEpithet { get; set; }
        [StringLength(255)]
        public string? TaxonRank { get; set; }
        [StringLength(255)]
        public string? Authors { get; set; }

        public Taxa? Taxa { get; set; }
    }
}