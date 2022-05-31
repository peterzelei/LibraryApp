using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common.Models
{
    internal class ReturnDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = Convert.ToDateTime(value);

            if (DateTime.Compare(date, DateTime.Now) < 0)
            {
                return new ValidationResult("The return date cannot be less then the borrowing date",
                new[] { validationContext.MemberName });
            }

            return null;
        }
    }
}
