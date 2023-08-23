using FastMember;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.RepositoryAccess;
using System.Data;
using System.Data.SqlClient;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;

namespace ProjectPerunAPI.Repository.Implementation
{
    public class MaterialDataRepository : IMaterialDataRepository
    {
        private readonly IConfiguration Configuration;
        private readonly string connectionString;
        private SqlConnection _conn;

        public MaterialDataRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:MainDB"];
            _conn = new SqlConnection(connectionString);
        }

        public async Task<DataTable> GetMaterialDataDatabase()
        {
            DataTable returnDatabase = new DataTable();
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetAllMaterialData");
            return returnDatabase;
        }

        public async Task<DataTable> GetOneMaterialDataDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@MaterialID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOneMaterialData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> UpdateMaterialDataDatabase(List<MaterialDataModel> materialData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@MaterialData", ListToTableMaterialData(materialData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateMaterialData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertMaterialDataDatabase(List<MaterialDataModel> materialData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@MaterialData", ListToTableMaterialData(materialData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertMaterialData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteMaterialDataDatabase(List<MaterialDataModel> materialData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@MaterialData", ListToTableMaterialData(materialData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteMaterialData", parameters);
            return returnDatabase;
        }

        private DataTable ListToTableMaterialData(List<MaterialDataModel> materialData)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(materialData, "ID", "Code", "MaterialType",
            "Description", "TimeStamp", "UserID", "Active"))
            {
                table.Load(reader);
            }
            return table;
        }
    }
}
