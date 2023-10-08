namespace crud_products_api.src.Models.Create;

public class AddressReadModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}
