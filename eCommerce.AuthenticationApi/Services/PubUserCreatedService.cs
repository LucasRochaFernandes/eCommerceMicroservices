using AutoMapper;
using eCommerce.AuthenticationApi.Communication.Profiles;
using eCommerce.AuthenticationApi.Domain.Entities;
using eCommerce.SharedLibrary.Messaging.User;
using MassTransit;

namespace eCommerce.AuthenticationApi.Services;

public class PubUserCreatedService
{
    private readonly IBus _bus;

    public PubUserCreatedService(IBus bus)
    {
        _bus = bus;
    }

    public async Task Execute(User user)
    {
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UserProfile>();
        }).CreateMapper();
        var userCreatedMessage = mapper.Map<UserCreatedMessage>(user);
        await _bus.Publish(userCreatedMessage);
    }
}