using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Repository;
using System.Data;

namespace ProjectPerunAPI.Services.Implementation
{
    public class OrdersService : IOrdersService
    {
        IOrdersRepository _ordersRepository;
        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<ResponseModelNew> GetOrders(string filter)
        {
            DataTable resultDatabase;
            resultDatabase = await _ordersRepository.GetOrdersDatabase(filter);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get elements from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> GetOneOrder(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _ordersRepository.GetOneOrderDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get order " + id + " from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> UpdateOrder(List<OrderModel> orderData)
        {
            DataTable resultDatabase;
            resultDatabase = await _ordersRepository.UpdateOrderDatabase(orderData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get orders from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> InsertOrder(List<OrderModel> orderData)
        {
            DataTable resultDatabase;
            resultDatabase = await _ordersRepository.InsertOrderDatabase(orderData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get orders from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> DeleteOrder(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _ordersRepository.DeleteOrderDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get order " + id + " from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> SetOrderAsFinished(int orderID)
        {
            DataTable resultDatabase;
            resultDatabase = await _ordersRepository.SetOrderAsFinished(orderID);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to set order " + orderID + "as finished in database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }
    }
}
