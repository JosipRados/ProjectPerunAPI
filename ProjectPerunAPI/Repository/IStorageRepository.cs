using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IStorageRepository
    {
        Task<DataTable> GetStorageDatabase();
        Task<DataTable> GetMaterialDatabase(int id);
        Task<DataTable> UpdateMaterialDatabasePrepare(List<MaterialTransactionModel> materialData);
        Task<DataTable> UpdateMaterialDatabaseCheck(int importBatchNumber);
        Task<DataTable> UpdateMaterialDatabaseImport(int importBatchNumber);
        Task<DataTable> InsertMaterialDatabasePrepare(List<MaterialTransactionModel> materialData);
        Task<DataTable> InsertMaterialDatabaseCheck(int importBatchNumber);
        Task<DataTable> DeleteMaterialDatabaseImport(int importBatchNumber);
        Task<DataTable> DeleteMaterialDatabasePrepare(List<MaterialTransactionModel> materialData);
        Task<DataTable> DeleteMaterialDatabaseCheck(int importBatchNumber);
    }
}