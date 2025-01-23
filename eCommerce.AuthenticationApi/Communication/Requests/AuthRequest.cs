using System.ComponentModel.DataAnnotations;

namespace eCommerce.AuthenticationApi.Communication.Requests;

public record AuthRequest(
    [Required] string Email,
    [Required] string Password
    );
