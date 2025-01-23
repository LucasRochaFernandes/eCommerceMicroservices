using AutoMapper;
using eCommerce.AuthenticationApi.Communication.Requests;
using eCommerce.AuthenticationApi.Domain.Entities;

namespace eCommerce.AuthenticationApi.Communication.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRequest, User>();
    }
}
