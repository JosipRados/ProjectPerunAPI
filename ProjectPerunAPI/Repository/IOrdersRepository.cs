using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IOrdersRepository
    {
        Task<DataTable> DeleteOrderDatabase(int id);
        Task<DataTable> GetOneOrderDatabase(int id);
        Task<DataTable> GetOrdersDatabase();
        Task<DataTable> InsertOrderDatabase(OrderModel orderData);
        Task<DataTable> UpdateOrderDatabase(OrderModel orderData);
    }
}