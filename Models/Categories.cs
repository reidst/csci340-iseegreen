using System.ComponentModel.DataAnnotations;

namespace csci340_iseegreen.Models
{
    public class Categories
    {
        [Key]
        [StringLength(255)]
        public string? Category { get; set; }
        [StringLength(255)]
        public string? Description { get; set; }
        public int Sort { get; set; }
        public long APG4sort { get; set; }
    }
}