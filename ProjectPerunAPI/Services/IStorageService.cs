using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Services
{
    public interface IStorageService
    {
        Task<ResponseModel> DeleteMaterialData(List<MaterialDeleteModel>? materialData);
        Task<ResponseModelNew> GetAllStorage();
        Task<ResponseModel> GetOneMaterial(int id);
        Task<ResponseModel> InsertMaterialData(List<MaterialTransactionModel>? materialData);
        Task<ResponseModel> UpdateMaterialData(List<MaterialTransactionModel>? materialData);
    }
}
