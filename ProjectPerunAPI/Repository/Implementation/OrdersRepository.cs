using ProjectPerunAPI.Models;
using ProjectPerunAPI.RepositoryAccess;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;
using System.Data.SqlClient;
using System.Data;

namespace ProjectPerunAPI.Repository.Implementation
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IConfiguration Configuration;
        private readonly string connectionString;
        private SqlConnection _conn;

        public OrdersRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:MainDB"];
            _conn = new SqlConnection(connectionString);
        }

        public async Task<DataTable> GetOrdersDatabase()
        {
            DataTable returnDatabase = new DataTable();
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOrders");
            return returnDatabase;
        }

        public async Task<DataTable> GetOneOrderDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@OrderID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOneOrder", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> UpdateOrderDatabase(OrderModel orderData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@OrderData", orderData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateOrder", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertOrderDatabase(OrderModel orderData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@OrderData", orderData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertOrder", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteOrderDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@OrderID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteOrder", parameters);
            return returnDatabase;
        }
    }
}
