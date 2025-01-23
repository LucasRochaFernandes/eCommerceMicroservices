using AutoMapper;
using eCommerce.AuthenticationApi.Communication.Requests;
using eCommerce.AuthenticationApi.Domain.Entities;
using eCommerce.SharedLibrary.Messaging.User;

namespace eCommerce.AuthenticationApi.Communication.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRequest, User>()
             .ForMember(dest => dest.Password, opt => opt.MapFrom(
                 src => BCrypt.Net.BCrypt.HashPassword(src.Password)));
        CreateMap<User, UserCreatedMessage>();
    }
}
