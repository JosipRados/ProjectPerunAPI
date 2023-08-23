using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IWarehouseService
    {
        Task<ResponseModelNew> DeleteWarehouseData(List<WarehouseDataModel>? warehouseData);
        Task<ResponseModelNew> GetOneWarehouseData(int id);
        Task<ResponseModelNew> GetWarehouseData();
        Task<ResponseModelNew> InsertWarehouseData(List<WarehouseDataModel>? warehouseData);
        Task<ResponseModelNew> UpdateWarehouseData(List<WarehouseDataModel>? warehouseData);
    }
}