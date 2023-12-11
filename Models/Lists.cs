using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace csci340_iseegreen.Models
{
    public class Lists
    {
        [Key]
        public required int Id { get; set; }
        [StringLength(255)]
        public required string Name { get; set; }
        [StringLength(450)]
        public required string OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public IdentityUser? Owner { get; set; }
    }
}