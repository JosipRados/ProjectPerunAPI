using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Repository;
using ProjectPerunAPI.Repository.Implementation;
using System.Data;

namespace ProjectPerunAPI.Services.Implementation
{
    public class ElementsService : IElementsService
    {
        IElementsRepository _elementsRepository;
        public ElementsService(IElementsRepository elementsRepository)
        {
            _elementsRepository = elementsRepository;
        }

        public async Task<ResponseModel> GetElements()
        {
            DataTable resultDatabase;
            resultDatabase = await _elementsRepository.GetElementsDatabase();
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get elements from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> GetOneElement(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _elementsRepository.GetOneElementDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get element " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> UpdateElement(ElementModel elementData)
        {
            DataTable resultDatabase;
            resultDatabase = await _elementsRepository.UpdateElementDatabase(elementData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get elements from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> InsertElement(ElementModel elementData)
        {
            DataTable resultDatabase;
            resultDatabase = await _elementsRepository.InsertElementDatabase(elementData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get elements from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> DeleteElement(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _elementsRepository.DeleteElementDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get element " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }
    }
}
