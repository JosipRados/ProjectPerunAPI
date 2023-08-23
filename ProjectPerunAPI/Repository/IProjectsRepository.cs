using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IProjectsRepository
    {
        Task<DataTable> DeleteProjectDatabase(List<ProjectModel> projectData);
        Task<DataTable> GetOneProjectDatabase(int id);
        Task<DataTable> GetProjectsDatabase();
        Task<DataTable> InsertProjectDatabase(List<ProjectModel> projectData, List<ProjectMaterialsModel> materialsData);
        Task<DataTable> UpdateProjectDatabase(List<ProjectModel> projectData, List<ProjectMaterialsModel> materialsData);
        Task<DataTable> GetProjectMaterials(int id);
        Task<DataTable> GetMaterialsDataNotOnProject(int id);
    }
}