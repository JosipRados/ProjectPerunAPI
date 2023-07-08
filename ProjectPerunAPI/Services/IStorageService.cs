using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Services
{
    public interface IStorageService
    {
        ResponseModel GetAllStorage();
        ResponseModel GetOneMaterial(int id);
        string UpdateMaterialData(MaterialModel materialData);
    }
}
