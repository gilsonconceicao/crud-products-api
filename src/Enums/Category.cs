using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace crud_products_api.src.Enums;

public enum Category
{
    [Display(Name = "Filmes")]
    [Description("Filmes")]
    Movie = 0,

    [Display(Name = "Livros")]
    [Description("Livros")]
    Books = 1,

    [Display(Name = "Jogos")]
    [Description("Jogos")]
    Games = 2,

    [Display(Name = "Veículos/automóveis")]
    [Description("Veículos/automóveis")]
    MotorVehicles = 3,

    [Display(Name = "Roupas")]
    [Description("Roupas")]
    lothes = 4,

    [Display(Name = "Alimentos e bebidas")]
    [Description("Alimentos e bebidas")]
    FoodandDrinks = 5
}
