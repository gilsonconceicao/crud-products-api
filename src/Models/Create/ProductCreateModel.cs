using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Enums;
using crud_products_api.src.Utility.Validations;

namespace crud_products_api.src.Models.Create;

public class ProductCreateModel
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Categoria é obrigatório")]
    public Category Category { get; set; }
    [Required(ErrorMessage = "Descrição é obrigatório")]
    [StringLength(130, MinimumLength = 10, ErrorMessage = "Descrição precisa conter de 10 à 130 caracteres")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Preço é obrigatório")]
    [Range(0, 500000, ErrorMessage = "Preço deve estar entre 0 à 500.000 mil")]
    [PriceValidationAttribute(field: "Preço")]
    public double Price { get; set; }
    [Required(ErrorMessage = "Disconto é obrigatório")]
    [Range(0, 500000, ErrorMessage = "Disconto deve estar entre 0 à 500.000 mil")]
    [PriceValidationAttribute(field: "Disconto")]
    public double Discount { get; set; }
    public AddressCreateModel? Address { get; set; }
}
