using ProjectPerunAPI.Models;
using ProjectPerunAPI.Repository;
using System.Data;

namespace ProjectPerunAPI.Services.Implementation
{
    public class WarehouseService : IWarehouseService
    {
        IWarehouseRepository _warehouseRepository;
        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<ResponseModelNew> GetWarehouseData()
        {
            DataTable resultDatabase;
            try
            {
                resultDatabase = await _warehouseRepository.GetWarehouseDatabase();
                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to GET Warehouse data from database.");
                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> GetOneWarehouseData(int id)
        {
            DataTable resultDatabase;
            try
            {
                resultDatabase = await _warehouseRepository.GetOneWarehouseDatabase(id);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to GET Warehouse " + id + " from database.");

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> UpdateWarehouseData(List<WarehouseDataModel>? warehouseData)
        {
            DataTable resultDatabase;
            if (warehouseData == null || warehouseData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _warehouseRepository.UpdateWarehouseDatabase(warehouseData);

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

        public async Task<ResponseModelNew> InsertWarehouseData(List<WarehouseDataModel>? warehouseData)
        {
            DataTable resultDatabase;
            if (warehouseData == null || warehouseData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _warehouseRepository.InsertWarehouseDatabase(warehouseData);

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

        public async Task<ResponseModelNew> DeleteWarehouseData(List<WarehouseDataModel>? warehouseData)
        {
            DataTable resultDatabase;
            if (warehouseData == null || warehouseData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _warehouseRepository.DeleteWarehouseDatabase(warehouseData);

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
