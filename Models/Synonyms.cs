using System.ComponentModel.DataAnnotations;

namespace csci340_iseegreen.Models
{
    public class Synonyms
    {
        [Key]
        [StringLength(255)]
        public string KewID { get; set; }
        [StringLength(255)]
        public string AcceptedKewID { get; set; }
        [StringLength(255)]
        public string SpeciesID { get; set; }
        [StringLength(255)]
        public string InfraspecificEpithet { get; set; }
        [StringLength(255)]
        public string TaxonRank { get; set; }
        [StringLength(255)]
        public string Authors { get; set; }

        public Taxa Species { get; set; }
    }
}