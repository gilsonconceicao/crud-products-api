using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_products_api.src.Models.Create
{
    public class AddressCreateModel
    {
        [Required(ErrorMessage = "Rua precisa ser preenchida")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Cidade precisa ser preenchida")]
        public string City { get; set; }
        [Required(ErrorMessage = "Estádo precisa ser preenchida")]
        public string State { get; set; }
        [Required(ErrorMessage = "CEP precisa ser preenchida")]
        public string ZipCode { get; set; }
    }
}