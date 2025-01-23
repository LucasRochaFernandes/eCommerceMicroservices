
using System.ComponentModel.DataAnnotations;

namespace eCommerce.OrderApi.Communication.Requests;

public record CreateOrderRequest(
    [Required] IList<ProductOrderRequest> Products
);

