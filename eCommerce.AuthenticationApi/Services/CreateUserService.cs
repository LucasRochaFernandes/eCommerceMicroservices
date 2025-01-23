using AutoMapper;
using eCommerce.AuthenticationApi.Communication.Profiles;
using eCommerce.AuthenticationApi.Communication.Requests;
using eCommerce.AuthenticationApi.Domain.Entities;
using eCommerce.SharedLibrary.Exceptions;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.AuthenticationApi.Services;

public class CreateUserService
{
    private readonly IGenericRepository<User> _userRepository;

    public CreateUserService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Execute(UserRequest request)
    {
        var userAlreadyExists = await _userRepository.GetByAsync(usr => usr.Email == request.Email);
        if (userAlreadyExists != null)
        {
            throw new ConflictException("User already exists.");
        }
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>()).CreateMapper();
        var userEntity = mapper.Map<User>(request);
        var userId = await _userRepository.CreateAsync(userEntity);
        return userId;
    }
}
