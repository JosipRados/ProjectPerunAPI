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
        public async Task<ResponseModel> GetAllStorage()
        {
            DataTable resultDatabase;
            resultDatabase = await _storageRepository.GetStorageDatabase();
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get all materials from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> GetOneMaterial(int id)
        {
            DataTable resultDatabase = await _storageRepository.GetMaterialDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to retrieve material data for selected material.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
            
        }

        public async Task<ResponseModel> UpdateMaterialData(List<MaterialTransactionModel>? materialData)
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
                    throw new Exception("ERROR: Unable to UPDATE material DATA, ImportBatchNumber not declared correctly.");

                /*CHECK*/
                returnDatabase = await _storageRepository.InsertMaterialDatabaseCheck(importBatchNumber);
                if (returnDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception("ERROR: Unable to UPDATE material DATA, please check items under batch number" + importBatchNumber.ToString());

                /*IMPORT*/
                returnDatabase = await _storageRepository.DeleteMaterialDatabaseImport(importBatchNumber);
                if (returnDatabase.Rows[0][0].ToString() != "OK")
                    throw new Exception("ERROR: Unable to UPDATE material DATA, error while importing data into storage.");
                if (returnDatabase == null || returnDatabase.Rows.Count == 0)
                    return new ResponseModel(true, "", "");
                else
                    return new ResponseModel(true, "", JsonConvert.SerializeObject(returnDatabase));

            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.Message, "");
            }

            #region OldCode
            //int importBatchNumber;

            //try
            //{
            //    if (materialData == null)
            //        throw new Exception("Empty Data!");

            //if (materialData.TransactionType == "UPDATE")
            //{
            //    /*PREPARE*/
            //    DataTable returnDatabase = _storageRepository.UpdateOneMaterialDatabasePrepare(materialData);
            //    if (returnDatabase.Rows[0]["StatusText"].ToString() == "ERR")
            //        throw new Exception("ERROR: Unable to UPDATE material DATA.");

            //    int.TryParse(returnDatabase.Rows[0]["StatusText"].ToString(), out importBatchNumber);
            //    if (importBatchNumber < 0)
            //        throw new Exception("ERROR: Unable to UPDATE material DATA, ImportBatchNumber not declared correctly.");

            //    /*CHECK*/
            //    returnDatabase = _storageRepository.UpdateOneMaterialDatabaseCheck(importBatchNumber);
            //    if (returnDatabase.Rows[0]["StatusText"].ToString() != "OK")
            //        throw new Exception("ERROR: Unable to UPDATE material DATA, please check following items: " + returnDatabase.Rows[0][0].ToString());

            //    /*IMPORT*/
            //    returnDatabase = _storageRepository.UpdateOneMaterialDatabaseImport(importBatchNumber);
            //    if (returnDatabase.Rows[0][0].ToString() != "OK")
            //        throw new Exception("ERROR: Unable to UPDATE material DATA, error while importing data into storage.");

            //    return new ResponseModel(true, "", "");
            //}
            //if (materialData.TransactionType == "EXPORT")
            //    return new ResponseModel();
            //    return new ResponseModel(true, "", "");
            //}
            //catch(Exception ex)
            //{
            //    return new ResponseModel(false, ex.Message, "");
            //}
            #endregion OldCode
        }

        public async Task<ResponseModel> InsertMaterialData(List<MaterialTransactionModel> materialData)
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
                returnDatabase = await _storageRepository.DeleteMaterialDatabaseImport(importBatchNumber);
                if (returnDatabase.Rows[0][0].ToString() != "OK")
                    throw new Exception("ERROR: Unable to INSERT material DATA, error while importing data into storage.");

                return new ResponseModel(true, "", "");

            }
            catch(Exception ex)
            {
                return new ResponseModel(false, ex.Message, "");
            }
        }

        public async Task<ResponseModel> DeleteMaterialData(List<MaterialTransactionModel> materialData)
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
                    throw new Exception("ERROR: Unable to INSERT material DATA.");

                int.TryParse(returnDatabase.Rows[0]["StatusText"].ToString(), out importBatchNumber);
                if (importBatchNumber < 0)
                    throw new Exception("ERROR: Unable to UPDATE material DATA, ImportBatchNumber not declared correctly.");

                /*CHECK*/
                returnDatabase = await _storageRepository.DeleteMaterialDatabaseCheck(importBatchNumber);
                if (returnDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception("ERROR: Unable to UPDATE material DATA, please check following items: " + returnDatabase.Rows[0][0].ToString());

                /*IMPORT*/
                returnDatabase = await _storageRepository.DeleteMaterialDatabaseImport(importBatchNumber);
                if (returnDatabase.Rows[0][0].ToString() != "OK")
                    throw new Exception("ERROR: Unable to UPDATE material DATA, error while importing data into storage.");

                return new ResponseModel(true, "", "");

            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.Message, "");
            }
        }
    }
}
