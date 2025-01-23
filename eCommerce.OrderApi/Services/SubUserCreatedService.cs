using AutoMapper;
using eCommerce.OrderApi.Communication.Profiles;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;
using eCommerce.SharedLibrary.Logging.Messages;
using eCommerce.SharedLibrary.Messaging.User;
using MassTransit;

namespace eCommerce.OrderApi.Services;

public class SubUserCreatedService : IConsumer<UserCreatedMessage>
{
    private readonly IGenericRepository<User> _userRepository;

    public SubUserCreatedService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Consume(ConsumeContext<UserCreatedMessage> context)
    {
        var message = context.Message;
        var userAlreadyExists = await _userRepository.GetByAsync(usr => usr.Email == message.Email);
        MessageReceived.LogMessage($"User Created Message Caught - UserId:{message!.Id}");
        if (userAlreadyExists is null)
        {
            MessageReceived.LogMessage($"User Added - UserId:{message!.Id}");
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>()).CreateMapper();
            var userEntity = mapper.Map<User>(message);
            await _userRepository.CreateAsync(userEntity);
        }
    }
}
