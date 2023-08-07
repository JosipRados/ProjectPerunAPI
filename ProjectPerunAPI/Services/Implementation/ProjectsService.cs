using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Repository;
using System.Data;

namespace ProjectPerunAPI.Services.Implementation
{
    public class ProjectsService : IProjectsService
    {
        IProjectsRepository _projectsRepository;
        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task<ResponseModel> GetProjects()
        {
            DataTable resultDatabase;
            resultDatabase = await _projectsRepository.GetProjectsDatabase();
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get projects from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> GetOneProject(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _projectsRepository.GetOneProjectDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get Project " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> UpdateProject(ProjectModel projectData)
        {
            DataTable resultDatabase;
            resultDatabase = await _projectsRepository.UpdateProjectDatabase(projectData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get Projects from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> InsertProject(ProjectModel projectData)
        {
            DataTable resultDatabase;
            resultDatabase = await _projectsRepository.InsertProjectDatabase(projectData);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get Projects from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }

        public async Task<ResponseModel> DeleteProject(int id)
        {
            DataTable resultDatabase;
            resultDatabase = await _projectsRepository.DeleteProjectDatabase(id);
            if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                return new ResponseModel(false, "Unable to get Project " + id + " from database.", "");
            return new ResponseModel(true, "", JsonConvert.SerializeObject(resultDatabase));
        }
    }
}
