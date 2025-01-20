using System.ComponentModel.DataAnnotations;

namespace eCommerce.OrderApi.Communication.Requests;
public record CreateProductRequest(
    [Required] Guid Id,
    [Required] decimal Price,
    [Required] int Stock
    );
