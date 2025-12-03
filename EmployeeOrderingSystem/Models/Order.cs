using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeOrderingSystem.Models
{
    public class Order
    {
        // Primary key
        [Key]
        public int Id { get; set; }

        // Foreign key to Employee
        [Required]
        public int EmployeeId { get; set; }

        // Date and time of the order
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // Total amount for the order
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        // Status of the order
        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, Preparing, Delivering, Delivered

        // Navigation property to Employee
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        // Navigation property to OrderItems
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
