using System.ComponentModel.DataAnnotations;

namespace eCommerce.OrderApi.Communication.Responses;
public record ProductOrderResponse(
    [Required] Guid Id,
    [Required] int Quantity
    );
