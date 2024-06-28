using jubo_project_api.Entities;

namespace jubo_project_api.Services.Interface;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> GetOrdersAsync(List<string> orderIds);
    public Task<Order> CreateOrderAsync(string message);
    public Task<Order> UpdateOrderAsync(Order order);
}
