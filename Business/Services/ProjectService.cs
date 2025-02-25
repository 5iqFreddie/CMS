using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, ICustomerRepository customerRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
    {
        if (!await _customerRepository.ExistsAsync(x => x.Id == form.CustomerId))
        {
            return false;
        }

        ProjectEntity? projectEntity = ProjectFactory.Create(form);

        if (projectEntity == null)
        {
            return false;
        }

        bool result = await _projectRepository.AddAsync(projectEntity);
        return result;

    }

    public async Task<IEnumerable<Project?>> GetProjectsAsync()
    {
        var projectEntities = await _projectRepository.GetAllAsync();
        var projects = projectEntities.Select(ProjectFactory.Create);

        return projects;
    }


    public async Task<bool> UpdateProjectAsync(int id, ProjectRegistrationForm updateForm)
    {
        // Fetch the existing project
        var existingProject = await _projectRepository.GetOneAsync(p => p.Id == id);
        if (existingProject == null)
        {
            return false; // Project not found
        }

        // Update project properties
        existingProject.ProjectName = updateForm.ProjectName;
        existingProject.Description = updateForm.Description;
        existingProject.CustomerId = updateForm.CustomerId;

        // Call UpdateAsync from BaseRepository
        return await _projectRepository.UpdateAsync(existingProject);
    }


}
