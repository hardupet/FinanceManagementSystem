using FinanceManagementSystem.Data;
using FinanceManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinanceManagementSystem.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProcessPayment(PaymentModel payment)
        {
            if (ModelState.IsValid)
            {
                if (IsCardValid(payment))
                {
                    // Payment is valid, you can proceed with your logic
                    // For example, save the payment details to the database
                    _context.Payment.Add(payment);
                    _context.SaveChanges();
                    return RedirectToAction("Confirmation");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credit card details are invalid. Please input correct details.");
                }
            }

            return View("Index", payment);
        }

        public IActionResult Confirmation()
        {
            // This is the confirmation page.
            return View();
        }

        private bool IsCardValid(PaymentModel payment)
        {
            // Implement your card validation logic here
            if (string.IsNullOrWhiteSpace(payment.CardNumber) ||
                payment.CardNumber.Length < 13 || payment.CardNumber.Length > 19 ||
                !int.TryParse(payment.CardNumber, out _) ||
                payment.ExpiryMonth < 1 || payment.ExpiryMonth > 12 ||
                !int.TryParse(payment.ExpiryMonth.ToString(), out _) ||
                !int.TryParse(payment.ExpiryYear.ToString(), out _) ||
                string.IsNullOrWhiteSpace(payment.CVV) ||
                (payment.CVV.Length < 3 || payment.CVV.Length > 4) ||
                !int.TryParse(payment.CVV, out _))
            {
                return false;
            }

            // Add more validation logic if needed
            return true;
        }
    }
}
