
using System.ComponentModel.DataAnnotations;

namespace eCommerce.OrderApi.Communication.Requests;

public record CreateOrderRequest(
    [Required] Guid UserId,
    [Required] IList<ProductOrderRequest> Products
);


