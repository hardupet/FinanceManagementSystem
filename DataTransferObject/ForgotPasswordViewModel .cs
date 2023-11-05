using System;
using System.ComponentModel.DataAnnotations;

namespace FinanceManagementSystem.DataTransferObject
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? SecurityQuestion { get; set; }

        [Required]
        public string? SecurityAnswer { get; set; }
    }

}


