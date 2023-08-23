using Newtonsoft.Json;

namespace ProjectPerunAPI.Models
{
    public class ProjectAndProjectMaterialsWrapperModel
    {
        public List<ProjectModel>? Projects { get; set; }
        public List<ProjectMaterialsModel>? Materials { get; set; }
    }
}
