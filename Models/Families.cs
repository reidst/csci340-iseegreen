using System.ComponentModel.DataAnnotations;

namespace csci340_iseegreen.Models
{
    public class Families
    {
        [Key]
        [StringLength(255)]
        public string family { get; set; }
        [StringLength(255)]
        public string TranslateTo { get; set; }
        [StringLength(255)]
        public Categories Category { get; set; }
        [StringLength(255)]
        public TaxonomicOrders TaxonomicOrder { get; set; }
    }
}