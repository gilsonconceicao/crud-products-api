using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_products_api.src.Enums
{
    public enum AbsoluePercentage
    {
        [Display(Name = "Absoluto")]
        [Description("Absolute")]
        Absolute = 0,

        [Display(Name = "Porcentagem")]
        [Description("Percentage")]
        Percentage = 1,
    }
}