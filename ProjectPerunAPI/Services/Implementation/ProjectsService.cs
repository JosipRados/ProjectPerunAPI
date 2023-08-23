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

        public async Task<ResponseModelNew> GetProjects()
        {
            DataTable resultDatabase;
            try
            {
                resultDatabase = await _projectsRepository.GetProjectsDatabase();
                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to GET Projects from database.");
                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> GetOneProject(int id)
        {
            DataTable resultDatabase;
            try
            {
                resultDatabase = await _projectsRepository.GetOneProjectDatabase(id);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to GET Project " + id + " from database.");

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> UpdateProject(List<ProjectModel>? projectData, List<ProjectMaterialsModel>? materialsData)
        {
            DataTable resultDatabase;
            if (projectData == null || projectData.Count == 0 || materialsData == null || materialsData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _projectsRepository.UpdateProjectDatabase(projectData, materialsData);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to UPDATE Project data from database.");

                if (resultDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception(resultDatabase.Rows[0]["StatusText"].ToString());

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> InsertProject(List<ProjectModel>? projectData, List<ProjectMaterialsModel>? materialsData)
        {
            DataTable resultDatabase;
            if (projectData == null || projectData.Count == 0 || materialsData == null || materialsData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _projectsRepository.InsertProjectDatabase(projectData, materialsData);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to INSERT Project data from database.");

                if (resultDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception(resultDatabase.Rows[0]["StatusText"].ToString());

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> DeleteProject(List<ProjectModel>? projectData)
        {
            DataTable resultDatabase;
            if (projectData == null || projectData.Count == 0)
                return new ResponseModelNew(false, "Request empty!", new DataTable());

            try
            {
                resultDatabase = await _projectsRepository.DeleteProjectDatabase(projectData);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to DELETE Project data from database.");

                if (resultDatabase.Rows[0]["StatusText"].ToString() != "OK")
                    throw new Exception(resultDatabase.Rows[0]["StatusText"].ToString());

                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> GetProjectMaterials(int projectID)
        {
            DataTable resultDatabase;

            try
            {
                resultDatabase = await _projectsRepository.GetProjectMaterials(projectID);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to GET Project Materials from database.");
                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }

        public async Task<ResponseModelNew> GetMaterialDataNotOnProject(int projectID)
        {
            DataTable resultDatabase;

            try
            {
                resultDatabase = await _projectsRepository.GetMaterialsDataNotOnProject(projectID);

                if (resultDatabase == null || resultDatabase.Rows.Count == 0)
                    throw new Exception("Unable to GET Materials Data from database.");
                return new ResponseModelNew(true, "", resultDatabase);
            }
            catch (Exception ex)
            {
                return new ResponseModelNew(false, ex.Message, new DataTable());
            }
        }
    }
}
