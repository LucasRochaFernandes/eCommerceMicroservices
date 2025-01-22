using System.ComponentModel.DataAnnotations;

namespace eCommerce.ProductApi.Communication.Requests;

public sealed record PubProductCreatedMessage(
    [Required] Guid Id,
    [Required] decimal Price,
    [Required] int Stock
    );
