using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Enums;
using Microsoft.OpenApi.Extensions;

namespace crud_products_api.src.Helpers
{
    public class GenericCalculation
    {
        public double CalculatePriceAndDiscount(double price, double discount, AbsoluePercentage typeOfCalculation)
        {
            if (typeOfCalculation.ToString() == "Percentage") 
            {
                int percentageValue = 015;
                double priceWithPercentage = price * percentageValue; 
                return price - priceWithPercentage;
            }
            return price * discount; 
        }
    }
}