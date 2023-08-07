using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IElementsRepository
    {
        Task<DataTable> DeleteElementDatabase(int id);
        Task<DataTable> GetElementsDatabase();
        Task<DataTable> GetOneElementDatabase(int id);
        Task<DataTable> InsertElementDatabase(ElementModel elementData);
        Task<DataTable> UpdateElementDatabase(ElementModel elementData);
    }
}