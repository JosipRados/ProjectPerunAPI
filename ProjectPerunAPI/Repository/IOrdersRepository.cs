using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IOrdersRepository
    {
        Task<DataTable> DeleteOrderDatabase(int id);
        Task<DataTable> GetOneOrderDatabase(int id);
        Task<DataTable> GetOrdersDatabase(string filter);
        Task<DataTable> InsertOrderDatabase(List<OrderModel> orderData);
        Task<DataTable> UpdateOrderDatabase(List<OrderModel> orderData);
        Task<DataTable> SetOrderAsFinished(int orderID);
    }
}