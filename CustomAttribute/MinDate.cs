using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.CustomAttribute
{
    internal class MinDate : ValidationAttribute
    {
      

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            
            if(value is DateTime dateValue)
            {
                if(dateValue.Date<DateTime.Now.Date)
                {
                    string errorMessage = ErrorMessage ?? $"Date must be on or after {DateTime.Now:yyyy-MM-dd}.";
                    return new ValidationResult(errorMessage);

                }
                return ValidationResult.Success;

            }
            return new ValidationResult("Invalid date format.");

        }
    }
}
