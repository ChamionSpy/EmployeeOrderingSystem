using System.ComponentModel.DataAnnotations;

namespace EmployeeOrderingSystem.Models
{
    public class Restaurant
    {
        // Primary key
        [Key]
        public int Id { get; set; }

        // Restaurant name
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Brief location description
        [StringLength(200)]
        public string LocationDescription { get; set; } = string.Empty;

        // Contact number
        [StringLength(20)]
        public string ContactNumber { get; set; } = string.Empty;

    }
}
