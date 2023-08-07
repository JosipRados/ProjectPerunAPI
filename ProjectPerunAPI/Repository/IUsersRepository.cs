using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IUsersRepository
    {
        Task<DataTable> DeleteUserDatabase(int id);
        Task<DataTable> GetOneUserDatabase(int id);
        Task<DataTable> GetUsersDatabase();
        Task<DataTable> InsertUserDatabase(UserModel userData);
        Task<DataTable> UpdateUserDatabase(UserModel userData);
    }
}