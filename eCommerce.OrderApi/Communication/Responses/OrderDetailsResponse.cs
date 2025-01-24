using eCommerce.OrderApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.OrderApi.Communication.Responses;
public sealed class OrderDetailsResponse
{
    [Required, EmailAddress] public string Email { get; set; }
    [Required] public string CEP { get; set; }
    [Required] public string FullAddress { get; set; }
    [Required] public string PhoneNumber { get; set; }
    [Required] public IList<ProductOrderResponse> Products { get; set; }
    [Required] public decimal TotalPrice { get; set; }
    [Required] public DateTime OrderDateTime { get; set; }
    [Required] public PaymentStatus PaymentStatus { get; set; }
    [Required] public OrderStatus OrderStatus { get; set; }
}
