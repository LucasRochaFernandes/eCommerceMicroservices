namespace eCommerce.SharedLibrary.Communication;

// This is designed to represent immutable data (Response)
public record ResponseFormat(bool flag = false, string message = null!);