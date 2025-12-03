using System.ComponentModel.DataAnnotations;

namespace EmployeeOrderingSystem.ViewModels
{
    // ViewModel for employee deposit form
    public class DepositViewModel
    {
        // Employee number input
        [Required(ErrorMessage = "Employee number is required")]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; } = string.Empty;

        // Deposit amount input
        [Required(ErrorMessage = "Deposit amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Deposit amount must be greater than 0")]
        [Display(Name = "Deposit Amount (R)")]
        public decimal DepositAmount { get; set; }
    }
}
