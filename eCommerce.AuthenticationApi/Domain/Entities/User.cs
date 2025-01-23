namespace eCommerce.AuthenticationApi.Domain.Entities;

public class User
{
    public Guid Id = Guid.NewGuid();
    public string Email { get; set; }
    public string Password { get; set; }
    public string CEP { get; set; }
    public string FullAddress { get; set; }
    public string PhoneNumber { get; set; }
}
