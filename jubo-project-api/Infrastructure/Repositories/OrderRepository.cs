using jubo_project_api.Entities;
using jubo_project_api.Helpers;
using jubo_project_api.Services.Interface;
using MongoDB.Driver;

namespace jubo_project_api.Infrastructure.Repositories;

public class OrderRepository(PatientOrderContext context, MongoDbHelper mongoDbHelper) : IOrderRepository
{
    public async Task<Order> CreateOrderAsync(string message)
    {
        var id = await mongoDbHelper.GetNextSequenceValueAsync(nameof(Order));
        var newOrder = new Order { Id = id.ToString(), Message = message };
        await context.Orders.InsertOneAsync(newOrder);
        return newOrder;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync(List<string> orderIds)
    {
        var result = await context.Orders.FindAsync(Builders<Order>.Filter.In("_id", orderIds));
        return result.ToEnumerable();
    }

    public async Task<Order> UpdateOrderAsync(Order order)
    {
        await context.Orders.UpdateOneAsync(
            Builders<Order>.Filter.Eq("_id", order.Id),
            Builders<Order>.Update.Set(p => p.Message, order.Message));

        return order;
    }

    public Task<bool> OrderExistAsync(string orderId)
        => context.Orders.Find(Builders<Order>.Filter.Eq("_id", orderId)).AnyAsync();
}
