using System.ComponentModel.DataAnnotations;

namespace eCommerce.SharedLibrary.Messaging.User;
public record UserCreatedMessage(
    [Required] Guid Id,
    [Required] string Email,
    [Required] string CEP,
    [Required] string FullAddress,
    [Required] string PhoneNumber
    );
