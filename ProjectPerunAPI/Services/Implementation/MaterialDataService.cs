﻿using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Repository;
using ProjectPerunAPI.Repository.Implementation;
using System.Data;

namespace ProjectPerunAPI.Services.Implementation
{
    public class MaterialDataService : IMaterialDataService
    {
        IMaterialDataRepository _materialsRepository;
        public MaterialDataService(IMaterialDataRepository materialDataRepository)
        {
            _materialsRepository = materialDataRepository;
        }

        public async Task<ResponseModelNew> GetMaterialData()
        {
            DataTable resultDatabase;
            try
            {
                resultDatabase = await _materialsRepository.GetMaterialDataDatabase();
                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to get MaterialData from database.");
                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch(Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> GetOneMaterialData(int id)
        {
            DataTable resultDatabase;
            try
            {
                resultDatabase = await _materialsRepository.GetOneMaterialDataDatabase(id);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to get MaterialData for ID " + id + " from database.");

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch(Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> UpdateMaterialData(List<MaterialDataModel>? materialData)
        {
            DataTable resultDatabase;
            if (materialData == null || materialData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _materialsRepository.UpdateMaterialDataDatabase(materialData);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to UPDATE MaterialData from database.");

                if (resultDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception(resultDatabase.Rows[0]["StatusText"].ToString());

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> InsertMaterialData(List<MaterialDataModel>? materialData)
        {
            DataTable resultDatabase;
            if (materialData == null || materialData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _materialsRepository.InsertMaterialDataDatabase(materialData);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to get elements from database.");

                if (resultDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception(resultDatabase.Rows[0]["StatusText"].ToString());

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch(Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> DeleteMaterialData(List<MaterialDataModel>? materialData)
        {
            DataTable resultDatabase;
            if (materialData == null || materialData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _materialsRepository.DeleteMaterialDataDatabase(materialData);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to get elements from database.");

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
