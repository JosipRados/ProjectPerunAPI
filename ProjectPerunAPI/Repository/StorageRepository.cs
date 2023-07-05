using ProjectPerunAPI.RepositoryAccess;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

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
    }
}
