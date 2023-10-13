using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Enums;

namespace crud_products_api.src.Models.Update
{
    public class ProductUpdateModel
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public int? StockQuantity { get; set; }
        public double? Discount { get; set; }
        public AddressUpdateModel? Address { get; set; }
    }
}