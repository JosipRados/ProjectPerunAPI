using FastMember;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.RepositoryAccess;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;
using System.Data.SqlClient;
using System.Data;

namespace ProjectPerunAPI.Repository.Implementation
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly IConfiguration Configuration;
        private readonly string connectionString;
        private SqlConnection _conn;

        public WarehouseRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:MainDB"];
            _conn = new SqlConnection(connectionString);
        }

        public async Task<DataTable> GetWarehouseDatabase()
        {
            DataTable returnDatabase = new DataTable();
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetAllWarehouseData");
            return returnDatabase;
        }

        public async Task<DataTable> GetOneWarehouseDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@WarehouseID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOneWarehouseData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> UpdateWarehouseDatabase(List<WarehouseDataModel> warehouseData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@WarehouseData", ListToTableWarehouseData(warehouseData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateWarehouseData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertWarehouseDatabase(List<WarehouseDataModel> warehouseData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@WarehouseData", ListToTableWarehouseData(warehouseData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertWarehouseData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteWarehouseDatabase(List<WarehouseDataModel> warehouseData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@WarehouseData", ListToTableWarehouseData(warehouseData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteWarehouseData", parameters);
            return returnDatabase;
        }

        private DataTable ListToTableWarehouseData(List<WarehouseDataModel> warehouseData)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(warehouseData, "ID", "Name", "Address",
            "Description", "TimeStamp", "UserID"))
            {
                table.Load(reader);
            }
            return table;
        }
    }
}
