using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IOrdersService
    {
        Task<ResponseModel> DeleteOrder(int id);
        Task<ResponseModel> GetOneOrder(int id);
        Task<ResponseModel> GetOrders();
        Task<ResponseModel> InsertOrder(OrderModel orderData);
        Task<ResponseModel> UpdateOrder(OrderModel orderData);
    }
}
