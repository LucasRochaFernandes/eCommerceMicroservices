namespace eCommerce.OrderApi.Domain.Entities;
public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; }
    public string CEP { get; set; }
    public string FullAddress { get; set; }
    public string PhoneNumber { get; set; }
}
