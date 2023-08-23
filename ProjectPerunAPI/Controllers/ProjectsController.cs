using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;
using System.Data;

namespace ProjectPerunAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        IProjectsService _projectsService;
        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetProjects()
        {
            return JsonConvert.SerializeObject( await _projectsService.GetProjects());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetOneProject(int id)
        {
            return JsonConvert.SerializeObject(await _projectsService.GetOneProject(id));
        }

        [HttpGet("project-materials/{id}")]
        public async Task<ActionResult<string>> GetProjectMaterials(int id)
        {
            return JsonConvert.SerializeObject(await _projectsService.GetProjectMaterials(id));
        }

        [HttpGet("materials-data/{id}")]
        public async Task<ActionResult<string>> GetMaterialDataNotOnProject(int id)
        {
            return JsonConvert.SerializeObject(await _projectsService.GetMaterialDataNotOnProject(id));
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateProject([FromBody] ProjectAndProjectMaterialsWrapperModel? projectData)
        {
            if (projectData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject(await _projectsService.UpdateProject(projectData.Projects, projectData.Materials));
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertProject([FromBody] ProjectAndProjectMaterialsWrapperModel? projectData)
        {
            if (projectData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject(await _projectsService.InsertProject(projectData.Projects, projectData.Materials));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteProject(ProjectWrapperModel projectData)
        {
            if (projectData == null)
                return JsonConvert.SerializeObject(new ResponseModelNew(false, "Empty request!", new DataTable()));
            return JsonConvert.SerializeObject(await _projectsService.DeleteProject(projectData.Projects));
        }
    }
}
