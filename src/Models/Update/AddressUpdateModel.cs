using System.ComponentModel.DataAnnotations;

namespace crud_products_api.src.Models.Update
{
    public class AddressUpdateModel
    {
#nullable disable
        [Required(ErrorMessage = "Rua precisa ser preenchida")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Cidade precisa ser preenchida")]
        public string City { get; set; }
        [Required(ErrorMessage = "Estádo precisa ser preenchida")]
        public string State { get; set; }
        [Required(ErrorMessage = "CEP precisa ser preenchida")]
        public string ZipCode { get; set; }
#nullable restore
    }
}
