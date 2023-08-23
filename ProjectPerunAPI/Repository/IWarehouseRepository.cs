using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IWarehouseRepository
    {
        Task<DataTable> DeleteWarehouseDatabase(List<WarehouseDataModel> warehouseData);
        Task<DataTable> GetOneWarehouseDatabase(int id);
        Task<DataTable> GetWarehouseDatabase();
        Task<DataTable> InsertWarehouseDatabase(List<WarehouseDataModel> warehouseData);
        Task<DataTable> UpdateWarehouseDatabase(List<WarehouseDataModel> warehouseData);
    }
}