using System.ComponentModel.DataAnnotations;

namespace eCommerce.AuthenticationApi.Communication.Requests;

public record UserRequest(
    [Required] string Email,
    [Required] string Password,
    [Required] string CEP,
    [Required] string FullAddress,
    [Required] string PhoneNumber
   );
