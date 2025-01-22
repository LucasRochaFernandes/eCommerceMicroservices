using System.ComponentModel.DataAnnotations;

namespace eCommerce.SharedLibrary.Messaging.Product;
public record ProductCreatedMessage(
    [Required] Guid Id,
    [Required] decimal Price,
    [Required] int Stock
    );
