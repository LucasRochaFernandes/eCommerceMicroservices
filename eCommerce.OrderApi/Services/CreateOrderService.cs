using AutoMapper;
using eCommerce.OrderApi.Communication.Profiles;
using eCommerce.OrderApi.Communication.Requests;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.OrderApi.Application.Services;
public class CreateOrderService
{
    private readonly IGenericRepository<Order> _orderRepository;

    public CreateOrderService(IGenericRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Execute(CreateOrderRequest request)
    {
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<OrderProfile>();
        }).CreateMapper();

        var orderEntity = mapper.Map<Order>(request);
        var orderId = await _orderRepository.CreateAsync(orderEntity);
        return orderId;
    }
}
