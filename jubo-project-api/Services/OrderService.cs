using jubo_project_api.Entities;
using jubo_project_api.Services.Interface;

namespace jubo_project_api.Services;

public class OrderService(IOrderRepository orderRepository, IPatientRepository patientRepository)
{
    public Task<IEnumerable<Order>> GetOrdersAsync(List<string> orderIds)
        => orderRepository.GetOrdersAsync(orderIds);

    public async Task<Order> CreateOrderAsync(string patientId, string message)
    {
        var order = await orderRepository.CreateOrderAsync(message);
        _ = await patientRepository.PushPatientOrderAsync(patientId, order.Id);
        return order;
    }

    public Task<Order> UpdateOrderAsync(Order order)
        => orderRepository.UpdateOrderAsync(order);
}
