using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Repository;
using ProjectPerunAPI.Repository.Implementation;
using System.Data;

namespace ProjectPerunAPI.Services.Implementation
{
    public class MaterialDataService : IMaterialDataService
    {
        IMaterialDataRepository _elementsRepository;
        public MaterialDataService(IMaterialDataRepository elementsRepository)
        {
            _elementsRepository = elementsRepository;
        }

        public async Task<ResponseModelNew> GetMaterialData()
        {
            DataTable resultDatabase;
            resultDatabase = await _elementsRepository.GetMaterialDataDatabase();
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get elements from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModel> GetOneMaterialData(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _elementsRepository.GetOneMaterialDataDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get element " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> UpdateMaterialData(MaterialDataModel elementData)
        {
            DataTable resultDatabase;
            resultDatabase = await _elementsRepository.UpdateMaterialDataDatabase(elementData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get elements from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> InsertMaterialData(MaterialDataModel elementData)
        {
            DataTable resultDatabase;
            resultDatabase = await _elementsRepository.InsertMaterialDataDatabase(elementData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get elements from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> DeleteMaterialData(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _elementsRepository.DeleteMaterialDataDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get element " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }
    }
}
