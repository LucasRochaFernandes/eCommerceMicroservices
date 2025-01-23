using System.ComponentModel.DataAnnotations;

namespace eCommerce.SharedLibrary.Messaging.Product;
public record ProductStockUpdatedMessage(
    [Required] Guid ProductId,
    [Required] int NewStock
    );