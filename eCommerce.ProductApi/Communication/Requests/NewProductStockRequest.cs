using System.ComponentModel.DataAnnotations;

namespace eCommerce.ProductApi.Communication.Requests;

public record NewProductStockRequest(
      [Required] int NewStock
    );
