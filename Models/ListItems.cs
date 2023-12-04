using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace csci340_iseegreen.Models
{
    [PrimaryKey(nameof(KewID), nameof(ListID))]
    public class ListItems
    {
        [StringLength(255)]
        public required string KewID { get; set; }
        public required int ListID { get; set; }
        [StringLength(255)]
        public int? LocationID { get; set; }
        [DataType(DataType.Date)]
        public DateTime TimeDiscovered { get; set; }
        [ForeignKey("KewID")]
        public Taxa? Plant { get; set; }
        [ForeignKey("ListID")]
        public Lists? List { get; set; }
        [ForeignKey("LocationID")]
        public Locations? Location { get; set; }
    }
}