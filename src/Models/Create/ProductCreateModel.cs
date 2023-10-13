using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using crud_products_api.src.Enums;

namespace crud_products_api.src.Models.Create;

public class ProductCreateModel
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Categoria é obrigatório")]
    public Category Category { get; set; }
    [Required(ErrorMessage = "Descrição é obrigatório")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Preço é obrigatório")]
    public double Price { get; set; }
    public AddressCreateModel? Address { get; set; }
}
