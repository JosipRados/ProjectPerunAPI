using ProjectPerunAPI.Models;
using ProjectPerunAPI.RepositoryAccess;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;
using System.Data.SqlClient;
using System.Data;
using FastMember;

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

        public async Task<DataTable> GetOrdersDatabase(string filter)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@Filter", filter, TypeParametar.NVarChar);
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetAllOrdersData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> GetOneOrderDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@OrderID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOneOrderData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> UpdateOrderDatabase(List<OrderModel> orderData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@OrderData", ListToTableOrderData(orderData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateOrderData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertOrderDatabase(List<OrderModel> orderData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@OrderData", ListToTableOrderData(orderData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertOrderData", parameters);
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

        public async Task<DataTable> SetOrderAsFinished(int orderID)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@OrderID", orderID, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spSetOrderAsFinished", parameters);
            return returnDatabase;
        }

        private DataTable ListToTableOrderData(List<OrderModel> orderData)
        {
            DataTable table = new DataTable();
            try
            {
                using (var reader = ObjectReader.Create(orderData, "ID", "ProjectID", "OrderedQuantity",
                "DateOrdered", "DateFinal", "Stage", "MaterialSeparated", "Finished", "MaterialPrice",
                "WorkerPrice", "ProductionTime", "FinishingTime", "TimeStamp", "UserID"))
                {
                    table.Load(reader);
                }
                return table;
            }
            catch(Exception ex)
            {
                return table;
            }
        }
    }
}
