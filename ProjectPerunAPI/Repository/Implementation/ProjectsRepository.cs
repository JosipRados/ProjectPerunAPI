using ProjectPerunAPI.Models;
using ProjectPerunAPI.RepositoryAccess;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;
using System.Data.SqlClient;
using System.Data;

namespace ProjectPerunAPI.Repository.Implementation
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly IConfiguration Configuration;
        private readonly string connectionString;
        private SqlConnection _conn;

        public ProjectsRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:MainDB"];
            _conn = new SqlConnection(connectionString);
        }

        public async Task<DataTable> GetProjectsDatabase()
        {
            DataTable returnDatabase = new DataTable();
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetProjects");
            return returnDatabase;
        }

        public async Task<DataTable> GetOneProjectDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ProjectID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOneProject", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> UpdateProjectDatabase(ProjectModel projectData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ProjectData", projectData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateProject", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertProjectDatabase(ProjectModel projectData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ProjectData", projectData, TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertProject", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteProjectDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ProjectID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteProject", parameters);
            return returnDatabase;
        }
    }
}
