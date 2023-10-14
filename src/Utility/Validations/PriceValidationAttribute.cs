using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_products_api.src.Utility.Validations
{
    public class PriceValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            double priceValue = (double)value;
            if (priceValue == null)
            {
                return new ValidationResult(errorMessage: "Preço não pode ser null");
            }
            if (priceValue == 0)
            {
                return new ValidationResult(errorMessage: "Preço precisa ser maior que 0 (zero)");
            }

            return ValidationResult.Success;
        }
    }
}