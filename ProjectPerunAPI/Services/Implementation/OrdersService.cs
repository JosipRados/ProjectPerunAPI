﻿using Newtonsoft.Json;
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

        public async Task<ResponseModel> GetOrders()
        {
            DataTable resultDatabase;
            resultDatabase = await _ordersRepository.GetOrdersDatabase();
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get elements from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> GetOneOrder(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _ordersRepository.GetOneOrderDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get order " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> UpdateOrder(OrderModel orderData)
        {
            DataTable resultDatabase;
            resultDatabase = await _ordersRepository.UpdateOrderDatabase(orderData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get orders from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> InsertOrder(OrderModel orderData)
        {
            DataTable resultDatabase;
            resultDatabase = await _ordersRepository.InsertOrderDatabase(orderData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get orders from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> DeleteOrder(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _ordersRepository.DeleteOrderDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get order " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }
    }
}
