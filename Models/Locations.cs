using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace csci340_iseegreen.Models
{
    public class Locations
    {
        [Key]
        public required int Id { get; set; }
        [StringLength(450)]
        public string? OwnerID { get; set; }
        [StringLength(255)]
        public required string Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        [StringLength(255)]
        public string? Notes { get; set; }
        [ForeignKey("OwnerID")]
        public IdentityUser? Owner { get; set; }
    }
}