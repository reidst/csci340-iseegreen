using System.ComponentModel.DataAnnotations;

namespace csci340_iseegreen.Models
{
    public class Genera
    {
        [Required]
        [StringLength(255)]
        public string? KewID { get; set; }
        [Key]
        [StringLength(255)]
        public string? GenusID { get; set; }
        [StringLength(255)]
        public string? FamilyID { get; set; }

        public Families? Family { get; set; }
    }
}