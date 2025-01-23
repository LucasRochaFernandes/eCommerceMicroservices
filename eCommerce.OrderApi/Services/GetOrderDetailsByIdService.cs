using AutoMapper;
using eCommerce.OrderApi.Communication.Profiles;
using eCommerce.OrderApi.Communication.Responses;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.OrderApi.Application.Services;
public class GetOrderDetailsByIdService
{
    private readonly IGenericRepository<Order> _orderRepository;

    public GetOrderDetailsByIdService(IGenericRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<OrderDetailsResponse> Execute(string userEmail)
    {
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<OrderProfile>();
        }).CreateMapper();
        var orderEntity = await _orderRepository.GetByAsync(order => order.User.Email == userEmail);
        var orderDetails = mapper.Map<OrderDetailsResponse>(orderEntity);
        return orderDetails;
    }
}
