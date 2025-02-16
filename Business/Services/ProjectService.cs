using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public class ProjectService(ProjectRepository projectRepository)
{
    private readonly ProjectRepository _projectRepository = projectRepository;

    public async Task CreateProjectAsync(ProjectRegistrationForm form)
    {
        var projectEntity = ProjectFactory.Create(form);
        await _projectRepository.AddAsync(projectEntity!);
    }
    public async Task<IEnumerable<Project?>> GetProjectsAsync()
    {
        var projectEntities = await _projectRepository.GetAsync();
        return projectEntities.Select(ProjectFactory.Create)!;
    }
    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
        return ProjectFactory.Create(projectEntity!);
    }
    public async Task<Project?> GetProjectByTitleAsync(string title)
    {
        var projectEntity = await _projectRepository.GetAsync(x => x.Title == title);
        return ProjectFactory.Create(projectEntity!);
    }
    public async Task<bool> UpdateProjectAsync(Project project)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == project.Id);
            await _projectRepository.UpdateAsync(projectEntity!);
            return true;
        }
        catch { return false; }
    }
    public async Task<bool> DeleteProjectAsync(int id)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
            await _projectRepository.DeleteAsync(projectEntity!);
            return true;
        }
        catch { return false; }
    }
}
