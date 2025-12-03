using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeOrderingSystem.Models
{
    public class OrderItem
    {
        // Primary key
        [Key]
        public int Id { get; set; }

        // Foreign key to Order
        [Required]
        public int OrderId { get; set; }

        // Foreign key to MenuItem
        [Required]
        public int MenuItemId { get; set; }

        // Quantity of the item in the order
        [Required]
        public int Quantity { get; set; } = 1;

        // Price of the item at the time of order
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPriceAtTimeOfOrder { get; set; }

        // Navigation property to Order
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        // Navigation property to MenuItem
        [ForeignKey("MenuItemId")]
        public MenuItem? MenuItem { get; set; }
    }
}
