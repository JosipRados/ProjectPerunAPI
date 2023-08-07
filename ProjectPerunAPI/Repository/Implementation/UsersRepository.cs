using ProjectPerunAPI.Models;
using ProjectPerunAPI.RepositoryAccess;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;
using System.Data.SqlClient;
using System.Data;


namespace ProjectPerunAPI.Repository.Implementation
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConfiguration Configuration;
        private readonly string connectionString;
        private SqlConnection _conn;

        public UsersRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:MainDB"];
            _conn = new SqlConnection(connectionString);
        }

        public async Task<DataTable> GetUsersDatabase()
        {
            DataTable returnDatabase = new DataTable();
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetusers");
            return returnDatabase;
        }

        public async Task<DataTable> GetOneUserDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@UserID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOneUser", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> UpdateUserDatabase(UserModel userData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@UserData", userData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateUser", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertUserDatabase(UserModel userData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@UserData", userData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertUser", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteUserDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@UserID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteUser", parameters);
            return returnDatabase;
        }
    }
}
