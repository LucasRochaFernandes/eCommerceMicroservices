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
    public async Task<OrderDetailsResponse> Execute(Guid id)
    {
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<OrderProfile>();
        }).CreateMapper();
        var orderEntities = await _orderRepository.FindByIdAsync(id);
        var orderDetails = mapper.Map<OrderDetailsResponse>(orderEntities);
        return orderDetails;
    }
}
