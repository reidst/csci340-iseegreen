using System.ComponentModel.DataAnnotations;

namespace csci340_iseegreen.Models
{
    public class Synonyms
    {
        [Key]
        [StringLength(255)]
        public string kew_id { get; set; }
        [StringLength(255)]
        public string accepted_kew_id { get; set; }
        [StringLength(255)]
        public Genera genus { get; set; }
        [StringLength(255)]
        public Genera species { get; set; }
        [StringLength(255)]
        public string InfraspecificEpithet { get; set; }
        [StringLength(255)]
        public string TaxonRank { get; set; }
        [StringLength(255)]
        public string Authors { get; set; }
    }
}