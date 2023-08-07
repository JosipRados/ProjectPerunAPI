using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IElementsService
    {
        Task<ResponseModel> DeleteElement(int id);
        Task<ResponseModel> GetElements();
        Task<ResponseModel> GetOneElement(int id);
        Task<ResponseModel> InsertElement(ElementModel elementData);
        Task<ResponseModel> UpdateElement(ElementModel elementData);
    }
}
