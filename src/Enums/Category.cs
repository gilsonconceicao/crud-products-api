using System.ComponentModel;

namespace crud_products_api.src.Enums;

public enum Category
{
    [Description("Filmes")]
    Movie = 0, 
    [Description("Livros")]
    Books = 1, 
    [Description("Jogos")]
    Games = 2, 
    [Description("Roupas")]
    lothes = 3, 
    [Description("Alimentos e bebidas")]
    FoodandDrinks = 4
}
