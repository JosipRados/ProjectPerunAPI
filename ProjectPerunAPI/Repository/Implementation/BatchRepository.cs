using FastMember;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.RepositoryAccess;
using System.Data;
using System.Data.SqlClient;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;

namespace ProjectPerunAPI.Repository.Implementation
{
    public class BatchRepository : IBatchRepository
    {
        private readonly IConfiguration Configuration;
        private readonly string connectionString;
        private SqlConnection _conn;

        public BatchRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:MainDB"];
            _conn = new SqlConnection(connectionString);
        }

        public async Task<DataTable> GetBatchDataDatabase()
        {
            DataTable returnDatabase = new DataTable();
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetAllBatchData");
            return returnDatabase;
        }

        public async Task<DataTable> GetOneBatchDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@BatchNumber", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOneBatchData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> GetNewBatchNumber()
        {
            DataTable returnDatabase = new DataTable();
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetNewBatchNumber");
            return returnDatabase;
        }

        public async Task<DataTable> UpdateBatchDataDatabase(List<BatchDataModel> batchData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@BatchData", ListToTableBatchData(batchData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateBatchData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertBatchDataDatabase(List<BatchDataModel> batchData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@BatchData", ListToTableBatchData(batchData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertBatchData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteBatchDataDatabase(List<BatchDataModel> batchData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@BatchData", ListToTableBatchData(batchData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteBatchData", parameters);
            return returnDatabase;
        }

        private DataTable ListToTableBatchData(List<BatchDataModel> batchData)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(batchData, "ID", "BatchNumber", "Sender",
            "TimeStamp", "UserID"))
            {
                table.Load(reader);
            }
            return table;
        }
    }
}
