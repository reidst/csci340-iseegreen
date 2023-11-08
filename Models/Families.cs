using System.ComponentModel.DataAnnotations;

namespace csci340_iseegreen.Models
{
    public class Families
    {
        [Key]
        [StringLength(255)]
        public string Family { get; set; }
        [StringLength(255)]
        public string TranslateTo { get; set; }
        [StringLength(255)]
        public string CategoryID { get; set; }
        [StringLength(255)]
        public string TaxonomicOrderID { get; set; }

        public Categories Category { get; set; }
        public TaxonomicOrders TaxonomicOrder { get; set; }
    }
}