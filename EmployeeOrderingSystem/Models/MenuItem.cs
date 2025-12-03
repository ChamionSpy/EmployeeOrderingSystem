using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeOrderingSystem.Models
{
    public class MenuItem
    {
        // Primary key
        [Key]
        public int Id { get; set; }

        // Foreign key to Restaurant
        [Required]
        public int RestaurantId { get; set; }

        // Menu item name
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Optional description
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        // Price of the item
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // Navigation property to related restaurant
        [ForeignKey("RestaurantId")]
        public Restaurant? Restaurant { get; set; }
    }
}
