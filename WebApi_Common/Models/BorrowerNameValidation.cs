﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common.Models
{
    class BorrowerNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var name = value.ToString();

            if (String.IsNullOrEmpty(name))
            {
                return new ValidationResult("The name cannot be null or empty",
                new[] { validationContext.MemberName });
            }

            if (String.IsNullOrWhiteSpace(name))
            {
                return new ValidationResult("The name cannot be null or whitespace",
                new[] { validationContext.MemberName });
            }

            foreach (var c in name)
            {
                if (!Char.IsLetterOrDigit(c) && c != ' ')
                {
                    return new ValidationResult("The name cannot special character",
                        new[] { validationContext.MemberName });
                }
            }

            return null;
        }
    }
}