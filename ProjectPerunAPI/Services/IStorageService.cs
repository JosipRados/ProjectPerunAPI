using System.Data;

namespace ProjectPerunAPI.Services
{
    public interface IStorageService
    {
        public DataTable GetAllElements();
    }
}
