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
        public DataTable GetAllElements()
        {
            return _storageRepository.GetAllStorageDatabase();
        }
    }
}
