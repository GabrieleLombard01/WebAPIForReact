using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPIForReact.Models;

namespace WebAPIForReact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("ReactEndPoint")]
    public class ProjectsController : ControllerBase
    {
        private static List<Project> projects = new List<Project>
        {
            new Project {Id = 1, Name = "project1", Description="description1"},
            new Project {Id = 2, Name = "project2", Description="description2"},
            new Project {Id = 3, Name = "project3", Description="description3"},
        };
        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return projects;
        }

        [HttpPost]
        public Project PostProject([FromBody] Project project)
        {
            project.Id = projects.Count() + 1;
            projects.Add(project);
            return project;
        }
    }
}
