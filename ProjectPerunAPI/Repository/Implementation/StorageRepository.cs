using FastMember;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.RepositoryAccess;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;

namespace ProjectPerunAPI.Repository.Implementation
{
    public class StorageRepository : IStorageRepository
    {
        private readonly IConfiguration Configuration;
        private readonly string connectionString;
        private SqlConnection _conn;

        public StorageRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:MainDB"];
            _conn = new SqlConnection(connectionString);
        }

        public async Task<DataTable> GetStorageDatabase()
        {
            DataTable returnDatabase = new DataTable();
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetAllStorage");
            return returnDatabase;
        }

        public async Task<DataTable> GetOneStorageDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@MaterialID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOneMaterial", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> GetLastMaterialNumberDatabase()
        {
            DataTable returnDatabase = new DataTable();
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetLastMaterialNumber");
            return returnDatabase;
        }

        public async Task<DataTable> UpdateMaterialDatabasePrepare(List<MaterialTransactionModel> materialData)
        {
            DataTable returnDatabase = new DataTable();
            DataTable dtMaterialData = ListToTableMaterialData(materialData);

            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@MaterialData", dtMaterialData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateMaterialData_01Prepare", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> UpdateMaterialDatabaseCheck(int importBatchNumber)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ImportBatchNumber", importBatchNumber, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateMaterialData_02Check", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> UpdateMaterialDatabaseImport(int importBatchNumber)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ImportBatchNumber", importBatchNumber, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateMaterialData_03Import", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertMaterialDatabasePrepare(List<MaterialTransactionModel> materialData)
        {
            DataTable returnDatabase = new DataTable();
            DataTable dtMaterialData = ListToTableMaterialData(materialData);

            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@MaterialData", dtMaterialData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertMaterialData_01Prepare", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertMaterialDatabaseCheck(int importBatchNumber)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ImportBatchNumber", importBatchNumber, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertMaterialData_02Check", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertMaterialDatabaseImport(int importBatchNumber)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ImportBatchNumber", importBatchNumber, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertMaterialData_03Import", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteMaterialDatabasePrepare(List<MaterialDeleteModel> materialData)
        {
            DataTable returnDatabase = new DataTable();
            DataTable dtMaterialData = ListToTableMaterialDelete(materialData);

            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@MaterialData", dtMaterialData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteMaterialData_01Prepare", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteMaterialDatabaseCheck(int importBatchNumber)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ImportBatchNumber", importBatchNumber, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteMaterialData_02Check", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteMaterialDatabaseImport(int importBatchNumber)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ImportBatchNumber", importBatchNumber, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteMaterialData_03Import", parameters);
            return returnDatabase;
        }

        /** HELPER METHODS **/

        private DataTable ListToTableMaterialData(List<MaterialTransactionModel> materialData)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(materialData, "Id", "Number", "Name", "Code", "TransactionType", "Quantity", 
            "Price", "ElementID", "Type", "WarehouseID", "LastChange",
            "UserID", "TimeStamp", "Reserved", "OnProject", "BatchID", "ImportBatchNumber"))
            {
                table.Load(reader);
            }
            return table;
        }

        private DataTable ListToTableMaterialDelete(List<MaterialDeleteModel> materialData)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(materialData, "MaterialID", "UserID"))
            {
                table.Load(reader);
            }
            return table;
        }
    }
}
