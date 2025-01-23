using eCommerce.AuthenticationApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.AuthenticationApi.Services;

public class GetAllUsersService
{
    private readonly IGenericRepository<User> _userRepository;

    public GetAllUsersService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ICollection<User>> Execute()
    {
        var result = await _userRepository.GetAllAsync();
        return result.ToList();
    }
}
