using ProjectPerunAPI.Models;

namespace ProjectPerunAPI.Services
{
    public interface IProjectsService
    {
        Task<ResponseModel> DeleteProject(int id);
        Task<ResponseModel> GetOneProject(int id);
        Task<ResponseModel> GetProjects();
        Task<ResponseModel> InsertProject(ProjectModel projectData);
        Task<ResponseModel> UpdateProject(ProjectModel projectData);
    }
}
