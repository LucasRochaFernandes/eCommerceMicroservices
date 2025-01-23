using AutoMapper;
using eCommerce.OrderApi.Communication.Profiles;
using eCommerce.OrderApi.Communication.Requests;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.SharedLibrary.Exceptions;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.OrderApi.Application.Services;
public class CreateOrderService
{
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IGenericRepository<User> _userRepository;

    public CreateOrderService(IGenericRepository<Order> orderRepository, IGenericRepository<User> userRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> Execute(CreateOrderRequest request, string userEmail)
    {
        var user = await _userRepository.GetByAsync(u => u.Email == userEmail);
        if (user is null)
        {
            throw new NotFoundException("User not found");
        }
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<OrderProfile>();
        }).CreateMapper();
        var orderEntity = mapper.Map<Order>(request);
        orderEntity.UserId = user.Id;
        var orderId = await _orderRepository.CreateAsync(orderEntity);
        return orderId;
    }
}
