namespace crud_products_api.src.Models;
public class Address
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public virtual Product Product { get; set; }
}
