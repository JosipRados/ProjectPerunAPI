using ProjectPerunAPI.Models;
using ProjectPerunAPI.RepositoryAccess;
using System.Data;
using System.Data.SqlClient;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;

namespace ProjectPerunAPI.Repository.Implementation
{
    public class ElementsRepository : IElementsRepository
    {
        private readonly IConfiguration Configuration;
        private readonly string connectionString;
        private SqlConnection _conn;

        public ElementsRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:MainDB"];
            _conn = new SqlConnection(connectionString);
        }

        public async Task<DataTable> GetElementsDatabase()
        {
            DataTable returnDatabase = new DataTable();
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetElements");
            return returnDatabase;
        }

        public async Task<DataTable> GetOneElementDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ElementID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOneElement", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> UpdateElementDatabase(ElementModel elementData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ElementData", elementData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateElement", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertElementDatabase(ElementModel elementData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ElementData", elementData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertElement", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteElementDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ElementID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteElement", parameters);
            return returnDatabase;
        }
    }
}
