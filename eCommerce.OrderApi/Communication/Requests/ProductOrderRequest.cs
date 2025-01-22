using System.ComponentModel.DataAnnotations;

namespace eCommerce.OrderApi.Communication.Requests;
public record ProductOrderRequest(
    [Required] Guid ProductId,
    [Required] int Quantity
);
