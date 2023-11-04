using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_products_api.src.Models.Create
{
#nullable disable
    public class ReviewCreateModel
    {
        [MinLength(5,
            ErrorMessage = "Comentário deve conter no mínimo 5 caracteres")]
        public string Comment { get; set; }
    }
#nullable restore
}