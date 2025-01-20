using System.ComponentModel.DataAnnotations;

namespace eCommerce.OrderApi.Communication.Requests;
public record CreateUserRequest(
    [Required] Guid Id,
    [Required] string FullAddress,
    [Required] string PhoneNumber,
    [Required] string CEP,
    [Required, EmailAddress] string Email
    );
