using BCrypt.Net;
using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Repository;
using ProjectPerunAPI.Repository.Implementation;
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

        public async Task<ResponseModelNew> GetUsers()
        {
            DataTable resultDatabase;
            resultDatabase = await _usersRepository.GetUsersDatabase();
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get elements from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> GetOneUser(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _usersRepository.GetOneUserDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get User " + id + " from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> UpdateUser(UserModel userData)
        {
            DataTable resultDatabase;
            resultDatabase = await _usersRepository.UpdateUserDatabase(userData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get Users from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> InsertUser(List<UserModel>? userData)
        {
            DataTable resultDatabase;
            if (userData == null || userData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            foreach(UserModel user in userData)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }

            try
            {
                resultDatabase = await _usersRepository.InsertUserDatabase(userData);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to INSERT User data to database.");

                if (resultDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception(resultDatabase.Rows[0]["StatusText"].ToString());

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> DeleteUser(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _usersRepository.DeleteUserDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModelNew(false, "Unable to get User " + id + " from database.", new DataTable());
            return new ResponseModelNew(true, "", resultDatabase);
        }

        public async Task<ResponseModelNew> LoginUser(LoginModel loginData)
        {
            DataTable resultDatabase;
            if (loginData == null)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _usersRepository.GetUserPasswordDatabase(loginData.Username);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to GET User password from database.");

                var isMatch = BCrypt.Net.BCrypt.Verify(loginData.Password, resultDatabase.Rows[0]["Password"].ToString());

                if (!isMatch)
                    throw new Exception("Wrong password, please try again.");
                else
                    return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }
        }
}
