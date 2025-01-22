using System.ComponentModel.DataAnnotations;

namespace eCommerce.OrderApi.Communication.Requests;
public record UpdateProductPriceRequest(
    [Required] Guid ProductId,
    [Required] decimal newPrice
);

