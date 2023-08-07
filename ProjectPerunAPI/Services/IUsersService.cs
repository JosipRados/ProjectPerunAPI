using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IUsersService
    {
        Task<ResponseModel> DeleteUser(int id);
        Task<ResponseModel> GetOneUser(int id);
        Task<ResponseModel> GetUsers();
        Task<ResponseModel> InsertUser(UserModel userData);
        Task<ResponseModel> UpdateUser(UserModel userData);
    }
}
