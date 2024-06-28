using jubo_project_api.Entities;
using jubo_project_api.Models;
using jubo_project_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace jubo_project_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(OrderService orderService) : ControllerBase
{
    [HttpPost("search")]
    public Task<IEnumerable<Order>> GetOrdersByPatientAsync(GetOrdersRequest request)
        => orderService.GetOrdersAsync(request.OrderIds);

    [HttpPost]
    public Task<Order> CreateOrderAsync([FromBody] CreateOrderRequest request)
        => orderService.CreateOrderAsync(request.PatientId, request.Message);

    [HttpPut("{id}")]
    public Task<Order> UpdateOrderAsync([FromRoute] string id, [FromBody] UpdateOrderRequest request)
        => orderService.UpdateOrderAsync(new Order { Id = id, Message = request.Message });
}
