using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IStorageRepository
    {
        DataTable GetAllStorageDatabase();
        DataTable GetOneMaterialDatabase(int id);
        DataTable UpdateOneMaterialDatabasePrepare(MaterialModel materialData);
        DataTable UpdateOneMaterialDatabaseCheck(int importBatchNumber);
        DataTable UpdateOneMaterialDatabaseImport(int importBatchNumber);
    }
}