using System.ComponentModel.DataAnnotations;

namespace eCommerce.OrderApi.Communication.Requests;
public record UpdateProductStockRequest(
    [Required] Guid ProductId,
    [Required] int newStock
    );
