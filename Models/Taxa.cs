using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csci340_iseegreen.Models
{
    public class Taxa
    {

        [Key]
        [StringLength(255)]
        public required string KewID { get; set; }
        [StringLength(255)]
        public string? GenusID { get; set; }
        [StringLength(255)]
        [DisplayName("Species")]
        public string? SpecificEpithet { get; set; }
        [StringLength(255)]
        [DisplayName("Infraspecies")]
        public string? InfraspecificEpithet { get; set; }
        [StringLength(255)]
        [DisplayName("Rank")]
        public string? TaxonRank { get; set; }
        [StringLength(255)]
        
        public string? HybridGenus { get; set; }
        [StringLength(255)]
        public string? HybridSpecies { get; set; }
        [StringLength(255)]
        public string? Authors { get; set; }
        [StringLength(255)]
        public string? USDAsymbol { get; set; }
        [StringLength(255)]
        public string? USDAsynonym { get; set; }
        [ForeignKey("GenusID")]
        public Genera? Genus { get; set; } 
    }
}