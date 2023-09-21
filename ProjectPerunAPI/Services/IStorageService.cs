using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Services
{
    public interface IStorageService
    {
        Task<ResponseModelNew> DeleteMaterialData(List<MaterialDeleteModel>? materialData);
        Task<ResponseModelNew> GetAllStorage();
        Task<ResponseModelNew> GetOneMaterial(int id);
        Task<ResponseModelNew> InsertMaterialData(List<MaterialTransactionModel>? materialData);
        Task<ResponseModelNew> UpdateMaterialData(List<MaterialTransactionModel>? materialData);
        Task<ResponseModelNew> GetLastMaterialNumber();
    }
}
