using System.Data.SqlClient;
using System.Data;
using ProjectPerunAPI.RepositoryAccess;
using ProjectPerunAPI.Models;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;

namespace ProjectPerunAPI.Repository.Implementation
{
    public class ShiftsRepository : IShiftsRepository
    {
        private readonly IConfiguration Configuration;
        private readonly string connectionString;
        private SqlConnection _conn;

        public ShiftsRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:MainDB"];
            _conn = new SqlConnection(connectionString);
        }

        public async Task<DataTable> GetShiftsDatabase()
        {
            DataTable returnDatabase = new DataTable();
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetShifts");
            return returnDatabase;
        }

        public async Task<DataTable> GetOneShiftDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ShiftID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOneShift", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> UpdateShiftDatabase(ShiftModel shiftData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ShiftData", shiftData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateShift", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertShiftDatabase(ShiftModel shiftData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ShiftData", shiftData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertShift", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteShiftDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ShiftID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteShift", parameters);
            return returnDatabase;
        }
    }
}
