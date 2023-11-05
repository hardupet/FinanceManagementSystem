using System;
using System.ComponentModel.DataAnnotations;

namespace FinanceManagementSystem.Models
{
    public class PaymentModel
    {
        public int Id { get; set; } // Primary key
        public string CardNumber { get; set; }

        [Display(Name = "Expiry Month")]
        public int ExpiryMonth { get; set; }

        [Display(Name = "Expiry Year")]
        public int ExpiryYear { get; set; }
        public string CVV { get; set; }
    }
}
