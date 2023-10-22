using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_products_api.src.Utility.Validations
{
    public class PriceValidationAttribute : ValidationAttribute
    {
        public string Field { get; set; }
        public PriceValidationAttribute(string field)
        {
            Field = field;
        }
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            double priceOrDiscountValue = (double)value;
            if (priceOrDiscountValue == null)
            {
                return new ValidationResult(errorMessage: $"{Field} não pode ser null");
            }
            if (priceOrDiscountValue == 0)
            {
                return new ValidationResult(errorMessage: $"{Field} precisa ser maior que 0 (zero)");
            }

            return ValidationResult.Success;
        }
    }
}