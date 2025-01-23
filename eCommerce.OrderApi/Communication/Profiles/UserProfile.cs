using AutoMapper;
using eCommerce.OrderApi.Communication.Requests;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.SharedLibrary.Messaging.User;

namespace eCommerce.OrderApi.Communication.Profiles;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<UserCreatedMessage, User>();
    }
}
