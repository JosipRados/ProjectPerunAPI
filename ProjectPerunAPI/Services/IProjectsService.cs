using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IProjectsService
    {
        Task<ResponseModelNew> DeleteProject(List<ProjectModel>? projectData);
        Task<ResponseModelNew> GetOneProject(int id);
        Task<ResponseModelNew> GetProjects();
        Task<ResponseModelNew> InsertProject(List<ProjectModel>? projectData, List<ProjectMaterialsModel>? materialsData);
        Task<ResponseModelNew> UpdateProject(List<ProjectModel>? projectData, List<ProjectMaterialsModel>? materialsData);
        Task<ResponseModelNew> GetProjectMaterials(int projectID);
        Task<ResponseModelNew> GetMaterialDataNotOnProject(int projectID);
    }
}
