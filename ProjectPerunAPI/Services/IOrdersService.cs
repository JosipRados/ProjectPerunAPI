using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IOrdersService
    {
        Task<ResponseModelNew> DeleteOrder(int id);
        Task<ResponseModelNew> GetOneOrder(int id);
        Task<ResponseModelNew> GetOrders(string filter);
        Task<ResponseModelNew> InsertOrder(List<OrderModel> orderData);
        Task<ResponseModelNew> UpdateOrder(List<OrderModel> orderData);
        Task<ResponseModelNew> SetOrderAsFinished(int orderID);
    }
}
