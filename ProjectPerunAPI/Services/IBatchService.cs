using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IBatchService
    {
        Task<ResponseModelNew> DeleteBatchData(List<BatchDataModel>? batchData);
        Task<ResponseModelNew> GetBatchData();
        Task<ResponseModelNew> GetOneBatchData(int id);
        Task<ResponseModelNew> InsertBatchData(List<BatchDataModel> batchData);
        Task<ResponseModelNew> UpdateBatchData(List<BatchDataModel> batchData);
        Task<ResponseModelNew> GetNewBatchNumber();
    }
}