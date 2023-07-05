using ProjectPerunAPI.Repository;
using System.Data;

namespace ProjectPerunAPI.Services.Implementation
{
    public class StorageService : IStorageService
    {
        IStorageRepository _storageRepository;
        public StorageService(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }
        public DataTable GetAllStorage()
        {
            return _storageRepository.GetAllStorageDatabase();
        }

        public DataTable GetOneMaterial(int id)
        {
            return _storageRepository.GetOneMaterialDatabase(id);
        }
    }
}
