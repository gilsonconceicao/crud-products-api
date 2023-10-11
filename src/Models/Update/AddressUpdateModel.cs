using System.ComponentModel.DataAnnotations;

namespace crud_products_api.src.Models.Update
{
    public class AddressUpdateModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
