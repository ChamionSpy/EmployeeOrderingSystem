using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeOrderingSystem.Models
{
    public class Employee
    {
        // Primary key
        [Key]
        public int Id { get; set; }

        // Employee name
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Unique employee number
        [Required]
        [StringLength(20)]
        public string EmployeeNumber { get; set; } = string.Empty;

        // Account balance (decimal format)
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; } = 0;

        // Last month a deposit was made
        public DateTime LastDepositMonth { get; set; } = new DateTime(1900, 1, 1);
    }
}
