using System.ComponentModel.DataAnnotations;

namespace csci340_iseegreen.Models
{
    public class Genera
    {
        [Required]
        [StringLength(255)]
        public string kew_id { get; set; }
        [Key]
        [StringLength(255)]
        public string genus { get; set; }
        public Families family { get; set; }
    }
}