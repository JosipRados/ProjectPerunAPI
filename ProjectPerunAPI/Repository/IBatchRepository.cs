using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IBatchRepository
    {
        Task<DataTable> DeleteBatchDataDatabase(List<BatchDataModel> batchData);
        Task<DataTable> GetBatchDataDatabase();
        Task<DataTable> GetNewBatchNumber();
        Task<DataTable> GetOneBatchDatabase(int id);
        Task<DataTable> InsertBatchDataDatabase(List<BatchDataModel> batchData);
        Task<DataTable> UpdateBatchDataDatabase(List<BatchDataModel> batchData);
    }
}