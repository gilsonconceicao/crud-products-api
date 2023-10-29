using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Enums;
using crud_products_api.src.Models.Create;
using crud_products_api.src.Utility.Validations;

namespace crud_products_api.src.Models.Update
{
    public class ProductUpdateModel
    {
        [Required(ErrorMessage = "Nome � obrigat�rio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Categoria � obrigat�rio")]
        public Category Category { get; set; }
        [Required(ErrorMessage = "Descri��o � obrigat�rio")]
        [StringLength(130, MinimumLength = 10, ErrorMessage = "Descri��o precisa conter de 10 � 130 caracteres")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Pre�o � obrigat�rio")]
        [Range(0, 500000, ErrorMessage = "Pre�o deve estar entre 0 � 500.000 mil")]
        [PriceValidationAttribute(field: "Pre�o")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Disconto � obrigat�rio")]
        [Range(0, 500000, ErrorMessage = "Disconto deve estar entre 0 � 500.000 mil")]
        [PriceValidationAttribute(field: "Disconto")]
        public double Discount { get; set; }
        public AddressCreateModel? Address { get; set; }
    }
}