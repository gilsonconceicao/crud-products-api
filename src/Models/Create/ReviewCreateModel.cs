using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_products_api.src.Models.Create
{
    public class ReviewCreateModel
    {
        [MinLength(10,
            ErrorMessage = "Comentário deve conter no mínimo 10 caracteres")]
        public string Comment { get; set; }
    }
}