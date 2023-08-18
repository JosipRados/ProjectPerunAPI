using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IMaterialDataRepository
    {
        Task<DataTable> DeleteMaterialDataDatabase(int id);
        Task<DataTable> GetMaterialDataDatabase();
        Task<DataTable> GetOneMaterialDataDatabase(int id);
        Task<DataTable> InsertMaterialDataDatabase(MaterialDataModel elementData);
        Task<DataTable> UpdateMaterialDataDatabase(MaterialDataModel elementData);
    }
}