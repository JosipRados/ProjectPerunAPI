using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IUsersService
    {
        Task<ResponseModelNew> DeleteUser(int id);
        Task<ResponseModelNew> GetOneUser(int id);
        Task<ResponseModelNew> GetUsers();
        Task<ResponseModelNew> InsertUser(List<UserModel>? userData);
        Task<ResponseModelNew> UpdateUser(UserModel userData);
        Task<ResponseModelNew> LoginUser(LoginModel loginData);
    }
}
