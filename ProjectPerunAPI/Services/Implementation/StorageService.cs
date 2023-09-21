using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Repository;
using System.Data;
using Newtonsoft;

namespace ProjectPerunAPI.Services.Implementation
{
    public class StorageService : IStorageService
    {
        IStorageRepository _storageRepository;
        public StorageService(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }
        public async Task<ResponseModelNew> GetAllStorage()
        {
            DataTable resultDatabase;
            resultDatabase = await _storageRepository.GetStorageDatabase();
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get all materials from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> GetOneMaterial(int id)
        {
            DataTable resultDatabase = await _storageRepository.GetOneStorageDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to retrieve material data for selected material.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);  
        }

        public async Task<ResponseModelNew> GetLastMaterialNumber()
        {
            DataTable resultDatabase;
            resultDatabase = await _storageRepository.GetLastMaterialNumberDatabase();
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get last material number from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> UpdateMaterialData(List<MaterialTransactionModel>? materialData)
        {
            int importBatchNumber;
            DataTable returnDatabase;

            if (materialData == null)
                throw new Exception("Empty Data!");
            try
            {
                /*PREPARE*/
                returnDatabase = await _storageRepository.UpdateMaterialDatabasePrepare(materialData);
                if (returnDatabase.Rows[0]["StatusText"].ToString() == "ERR")
                    throw new Exception("ERROR: Unable to INSERT material DATA.");

                int.TryParse(returnDatabase.Rows[0]["StatusText"].ToString(), out importBatchNumber);
                if (importBatchNumber < 0)
                    throw new Exception("ERROR: Unable to UPDATE material DATA, ImportBatchNumber not declared correctly.");

                /*CHECK*/
                returnDatabase = await _storageRepository.UpdateMaterialDatabaseCheck(importBatchNumber);
                if (returnDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception("ERROR: Unable to UPDATE material DATA, please check items under batch number" + importBatchNumber.ToString());

                /*IMPORT*/
                returnDatabase = await _storageRepository.UpdateMaterialDatabaseImport(importBatchNumber);

                if (returnDatabase == null || returnDatabase.Rows.Count == 0)
                    return new ResponseModelNew(true, "", new DataTable());
                else
                    return new ResponseModelNew(true, "", returnDatabase);

            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> InsertMaterialData(List<MaterialTransactionModel>? materialData)
        {
            int importBatchNumber;
            DataTable returnDatabase;

            if (materialData == null)
                throw new Exception("Empty Data!");
            try
            {
                /*PREPARE*/
                returnDatabase = await _storageRepository.InsertMaterialDatabasePrepare(materialData);
                if (returnDatabase.Rows[0]["StatusText"].ToString() == "ERR")
                    throw new Exception("ERROR: Unable to INSERT material DATA.");

                int.TryParse(returnDatabase.Rows[0]["StatusText"].ToString(), out importBatchNumber);
                if (importBatchNumber < 0)
                    throw new Exception("ERROR: Unable to INSERT material DATA, ImportBatchNumber not declared correctly.");

                /*CHECK*/
                returnDatabase = await _storageRepository.InsertMaterialDatabaseCheck(importBatchNumber);
                if (returnDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception("ERROR: Unable to INSERT material DATA, please check items under batch number" + importBatchNumber.ToString());

                /*IMPORT*/
                returnDatabase = await _storageRepository.InsertMaterialDatabaseImport(importBatchNumber);

                if (returnDatabase == null || returnDatabase.Rows.Count == 0)
                    return new ResponseModelNew(true, "", new DataTable());
                else
                    return new ResponseModelNew(true, "", returnDatabase);

            }
            catch(Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> DeleteMaterialData(List<MaterialDeleteModel>? materialData)
        {
            int importBatchNumber;
            DataTable returnDatabase;

            if (materialData == null)
                throw new Exception("Empty Data!");
            try
            {
                /*PREPARE*/
                returnDatabase = await _storageRepository.DeleteMaterialDatabasePrepare(materialData);
                if (returnDatabase.Rows[0]["StatusText"].ToString() == "ERR")
                    throw new Exception("ERROR: Unable to DELETE material DATA.");

                int.TryParse(returnDatabase.Rows[0]["StatusText"].ToString(), out importBatchNumber);
                if (importBatchNumber < 0)
                    throw new Exception("ERROR: Unable to DELETE material DATA, ImportBatchNumber not declared correctly.");

                /*CHECK*/
                returnDatabase = await _storageRepository.DeleteMaterialDatabaseCheck(importBatchNumber);
                if (returnDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception("ERROR: Unable to DELETE material DATA, please check following items: " + returnDatabase.Rows[0][0].ToString());

                /*IMPORT*/
                returnDatabase = await _storageRepository.DeleteMaterialDatabaseImport(importBatchNumber);

                if (returnDatabase == null || returnDatabase.Rows.Count == 0)
                    return new ResponseModelNew(true, "", new DataTable());
                else
                    return new ResponseModelNew(true, "", returnDatabase);

                return new ResponseModelNew(true, "", new DataTable());

            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> ExportMaterialToOrder(List<OrderMaterialModel> materialData)
        {

        }
    }
}
