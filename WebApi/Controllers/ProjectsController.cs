using Business.Interfaces;
using Business.Models;
using Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;


    [HttpPost]
    public async Task<IActionResult> Create(ProjectRegistrationForm regform)
    {
        if (!ModelState.IsValid && regform.CustomerId < 1)
        {
            return BadRequest();
        }

        var result = await _projectService.CreateProjectAsync(regform);

        return result
            ? Created("", null)
            : Problem();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetProjectsAsync();

        return projects == null || !projects.Any()
            ? NotFound("No projects found.")
            : Ok(projects);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProjectRegistrationForm updateForm)
    {
        if (id < 1 || !ModelState.IsValid)
        {
            return BadRequest("Invalid request.");
        }

        var updateSuccess = await _projectService.UpdateProjectAsync(id, updateForm);
        if (!updateSuccess)
        {
            return NotFound($"Project with ID {id} not found.");
        }

        return NoContent();
    }



}