using System.ComponentModel.DataAnnotations;

namespace eCommerce.OrderApi.Communication.Responses;
public record OrderCreatedResponse(
    [Required] Guid OrderId
    );
