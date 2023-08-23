using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IMaterialDataService
    {
        Task<ResponseModelNew> DeleteMaterialData(List<MaterialDataModel>? materialData);
        Task<ResponseModelNew> GetMaterialData();
        Task<ResponseModelNew> GetOneMaterialData(int id);
        Task<ResponseModelNew> InsertMaterialData(List<MaterialDataModel>? materialData);
        Task<ResponseModelNew> UpdateMaterialData(List<MaterialDataModel>? materialData);
    }
}
