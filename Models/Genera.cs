using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csci340_iseegreen.Models
{
    public class Genera
    {
        [StringLength(255)]
        public required string KewID { get; set; }
        [Key]
        [StringLength(255)]
        public required string GenusID { get; set; }
        [StringLength(255)]
        public string? FamilyID { get; set; }
        [ForeignKey("FamilyID")]
        public Families? Family { get; set; }
    }
}