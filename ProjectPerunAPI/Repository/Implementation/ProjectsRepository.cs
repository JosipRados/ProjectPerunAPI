using ProjectPerunAPI.Models;
using ProjectPerunAPI.RepositoryAccess;
using static ProjectPerunAPI.RepositoryAccess.TypeParameter;
using System.Data.SqlClient;
using System.Data;
using FastMember;

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
            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetAllProjectData");
            return returnDatabase;
        }

        public async Task<DataTable> GetOneProjectDatabase(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ProjectID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetOneProjectData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> UpdateProjectDatabase(List<ProjectModel> projectData, List<ProjectMaterialsModel> materialsData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ProjectData", ListToTableProjectData(projectData), TypeParametar.Structured);
            parameters.ParametarAdd("@MaterialsData", ListToTableProjectMaterialData(materialsData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spUpdateProjectData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> InsertProjectDatabase(List<ProjectModel> projectData, List<ProjectMaterialsModel> materialsData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ProjectData", ListToTableProjectData(projectData), TypeParametar.Structured);
            parameters.ParametarAdd("@MaterialsData", ListToTableProjectMaterialData(materialsData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spInsertProjectData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> DeleteProjectDatabase(List<ProjectModel> projectData)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ProjectData", ListToTableProjectData(projectData), TypeParametar.Structured);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spDeleteProjectData", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> GetProjectMaterials(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ProjectID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetProjectMaterials", parameters);
            return returnDatabase;
        }

        public async Task<DataTable> GetMaterialsDataNotOnProject(int id)
        {
            DataTable returnDatabase = new DataTable();
            DataAccessParameterList parameters = new DataAccessParameterList();
            parameters.ParametarAdd("@ProjectID", id, TypeParametar.BigInt);

            await SqlAccessManager.SelectDataAsync(_conn, CommandType.StoredProcedure, returnDatabase, "spGetAllMaterialDataNotOnAProject", parameters);
            return returnDatabase;
        }

        private DataTable ListToTableProjectData(List<ProjectModel> projectData)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(projectData, "ID", "Name", "Company",
            "Description", "TimeStamp", "UserID", "Active"))
            {
                table.Load(reader);
            }
            return table;
        }

        private DataTable ListToTableProjectMaterialData(List<ProjectMaterialsModel> materialData)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(materialData, "ID", "ProjectID", "MaterialID",
            "Quantity", "MaterialType", "Department", "TimeStamp", "UserID", "MaterialCode"))
            {
                table.Load(reader);
            }
            return table;
        }
    }
}
