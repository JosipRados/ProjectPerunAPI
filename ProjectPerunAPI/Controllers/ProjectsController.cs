using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPerunAPI.Models;
using ProjectPerunAPI.Services;

namespace ProjectPerunAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        IProjectsService _projectsService;
        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel>> GetProjects()
        {
            return await _projectsService.GetProjects();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel>> GetOneProject(int id)
        {
            return await _projectsService.GetOneProject(id);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> UpdateProject([FromBody] ProjectModel projectData)
        {
            return await _projectsService.UpdateProject(projectData);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> InsertProject([FromBody] ProjectModel projectData)
        {
            return await _projectsService.InsertProject(projectData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel>> DeleteProject(int id)
        {
            return await _projectsService.DeleteProject(id);
        }
    }
}
