using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IMaterialDataRepository
    {
        Task<DataTable> DeleteMaterialDataDatabase(List<MaterialDataModel> materialData);
        Task<DataTable> GetMaterialDataDatabase();
        Task<DataTable> GetOneMaterialDataDatabase(int id);
        Task<DataTable> InsertMaterialDataDatabase(List<MaterialDataModel> materialData);
        Task<DataTable> UpdateMaterialDataDatabase(List<MaterialDataModel> materialData);
    }
}