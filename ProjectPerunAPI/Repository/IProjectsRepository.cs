using ProjectPerunAPI.Models;
using System.Data;

namespace ProjectPerunAPI.Repository
{
    public interface IProjectsRepository
    {
        Task<DataTable> DeleteProjectDatabase(int id);
        Task<DataTable> GetOneProjectDatabase(int id);
        Task<DataTable> GetProjectsDatabase();
        Task<DataTable> InsertProjectDatabase(ProjectModel projectData);
        Task<DataTable> UpdateProjectDatabase(ProjectModel projectData);
    }
}