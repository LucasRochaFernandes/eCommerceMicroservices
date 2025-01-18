using System.ComponentModel.DataAnnotations;

namespace eCommerce.ProductApi.Communication.Requests;
public record ProductRequest(
    [Required] string Name,
    [Required] decimal Price,
    int Stock
    );
