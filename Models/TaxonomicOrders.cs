using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace csci340_iseegreen.Models
{
    public class TaxonomicOrders
    {
        [Key]
        [StringLength(255)]
        public string? TaxonomicOrder { get; set; }
        [StringLength(255)]
        public string? SortLevel1Heading { get; set; }
        [DefaultValue(0)]
        public int SortLevel1 { get; set; }
        [StringLength(255)]
        public string? SortLevel2Heading { get; set; }
        [DefaultValue(0)]
        public int SortLevel2 { get; set; }
        [StringLength(255)]
        public string? SortLevel3Heading { get; set; }
        [DefaultValue(0)]
        public int SortLevel3 { get; set; }
        [StringLength(255)]
        public string? SortLevel4Heading { get; set; }
        [DefaultValue(0)]
        public int SortLevel4 { get; set; }
        [StringLength(255)]
        public string? SortLevel5Heading { get; set; }
        [DefaultValue(0)]
        public int SortLevel5 { get; set; }
        [StringLength(255)]
        public string? SortLevel6Heading { get; set; }
        [DefaultValue(0)]
        public int SortLevel6 { get; set; }
    }
}