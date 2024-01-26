﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
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

        // ---------- VERBO PER CREATE ----------
        [HttpPost]
        public Project PostProject([FromBody] Project project)
        {
            project.Id = projects.Count() + 1;
            projects.Add(project);
            return project;
        }

        // ---------- VERBI PER UPDATE ----------
        [HttpGet("{Id}")]
        public Project? GetProject(long Id) 
        {
            return projects.Find(p => p.Id == Id);
        }


        [HttpPut]
        public IActionResult UpdateProject([FromBody] Project updatedProject)
        {
            Project existingProject = null;

            foreach (var project in projects)
            {
                if (project.Id == updatedProject.Id)
                {
                    existingProject = project;
                    break;
                }
            }

            if (existingProject == null)
            {
                return NotFound(); // 404 - Not Found
            }


            return Ok(existingProject); // 200 - Ok
        }

    }
    // ------------------------------------------------------- 


}

