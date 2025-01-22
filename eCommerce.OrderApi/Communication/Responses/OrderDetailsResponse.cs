using eCommerce.OrderApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.OrderApi.Communication.Responses;
public record OrderDetailsResponse(
    [Required, EmailAddress] string Email,
    [Required] string CEP,
    [Required] string FullAddress,
    [Required] string PhoneNumber,
    [Required] IList<ProductOrderResponse> Products,
    [Required] decimal TotalPrice,
    [Required] DateTime OrderDateTime,
    [Required] PaymentStatus PaymentStatus,
    [Required] OrderStatus OrderStatus
    );
