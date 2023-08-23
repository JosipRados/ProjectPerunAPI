using ProjectPerunAPI.Models;
using ProjectPerunAPI.Repository;
using System.Data;

namespace ProjectPerunAPI.Services.Implementation
{
    public class BatchService : IBatchService
    {
        IBatchRepository _batchRepository;
        public BatchService(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public async Task<ResponseModelNew> GetBatchData()
        {
            DataTable resultDatabase;
            try
            {
                resultDatabase = await _batchRepository.GetBatchDataDatabase();
                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to GET Batch data from database.");
                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> GetOneBatchData(int id)
        {
            DataTable resultDatabase;
            try
            {
                resultDatabase = await _batchRepository.GetOneBatchDatabase(id);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to GET Batch " + id + " from database.");

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> GetNewBatchNumber()
        {
            DataTable resultDatabase;
            try
            {
                resultDatabase = await _batchRepository.GetNewBatchNumber();

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to GET New Batch id from database.");

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> UpdateBatchData(List<BatchDataModel> batchData)
        {
            DataTable resultDatabase;
            if (batchData == null || batchData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _batchRepository.UpdateBatchDataDatabase(batchData);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to UPDATE Batch data from database.");

                if (resultDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception(resultDatabase.Rows[0]["StatusText"].ToString());

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> InsertBatchData(List<BatchDataModel> batchData)
        {
            DataTable resultDatabase;
            if (batchData == null || batchData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _batchRepository.InsertBatchDataDatabase(batchData);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to INSERT Batch data to database.");

                if (resultDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception(resultDatabase.Rows[0]["StatusText"].ToString());

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> DeleteBatchData(List<BatchDataModel>? batchData)
        {
            DataTable resultDatabase;
            if (batchData == null || batchData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _batchRepository.DeleteBatchDataDatabase(batchData);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to DELETE Batch data from database.");

                if (resultDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception(resultDatabase.Rows[0]["StatusText"].ToString());

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }
    }
}
