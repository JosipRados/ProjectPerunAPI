using ProjectPerunAPI.RepositoryAccess;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;

namespace ProjectPerunAPI.Repository
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

        public DataTable GetAllStorageDatabase()
        {
            DataTable materijalSkladiste = new DataTable();
            SqlAccessManager.SelectData(_conn, CommandType.StoredProcedure, materijalSkladiste, "spGetAllStorage");
            return materijalSkladiste;
        }

        public DataTable GetOneMaterialDatabase(int id)
        {
            DataTable oneMaterial = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@MaterialID", id, TypeParametar.BigInt);

            SqlAccessManager.SelectData(_conn, CommandType.StoredProcedure, oneMaterial, "spGetOneStorage", parameters);
            return oneMaterial;
        }
    }
}
