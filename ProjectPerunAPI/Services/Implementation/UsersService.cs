using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Repository;
using System.Data;


namespace ProjectPerunAPI.Services.Implementation
{
    public class UsersService : IUsersService
    {
        IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<ResponseModel> GetUsers()
        {
            DataTable resultDatabase;
            resultDatabase = await _usersRepository.GetUsersDatabase();
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get elements from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> GetOneUser(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _usersRepository.GetOneUserDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get User " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> UpdateUser(UserModel userData)
        {
            DataTable resultDatabase;
            resultDatabase = await _usersRepository.UpdateUserDatabase(userData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get Users from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> InsertUser(UserModel userData)
        {
            DataTable resultDatabase;
            resultDatabase = await _usersRepository.InsertUserDatabase(userData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get Users from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> DeleteUser(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _usersRepository.DeleteUserDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get User " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }
    }
}
