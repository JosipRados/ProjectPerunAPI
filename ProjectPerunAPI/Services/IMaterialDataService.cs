using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IMaterialDataService
    {
        Task<ResponseModel> DeleteMaterialData(int id);
        Task<ResponseModelNew> GetMaterialData();
        Task<ResponseModel> GetOneMaterialData(int id);
        Task<ResponseModel> InsertMaterialData(MaterialDataModel elementData);
        Task<ResponseModel> UpdateMaterialData(MaterialDataModel elementData);
    }
}
