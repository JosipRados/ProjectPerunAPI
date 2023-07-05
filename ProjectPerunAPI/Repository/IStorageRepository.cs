using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IStorageRepository
    {
        DataTable GetAllStorageDatabase();
    }
}