using System.Data;

namespace ProjectPerunAPI.Services
{
    public interface IStorageService
    {
        public DataTable GetAllStorage();
        DataTable GetOneMaterial(int id);
    }
}
