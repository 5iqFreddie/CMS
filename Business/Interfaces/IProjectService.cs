using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<bool> CreateProjectAsync(ProjectRegistrationForm form);
        Task<IEnumerable<Project?>> GetProjectsAsync();
        Task<bool> UpdateProjectAsync(int id, ProjectRegistrationForm updateForm);
    }
}