using Business.Factories;
using Business.Models;
using Data.Repositories;
using Data.Entities;

namespace Business.Services;

public class ProjectService(ProjectRepository projectRepository, CustomerRepository customerRepository, StatusTypeRepository statusRepository, UserRepository userRepository, ProductRepository productRepository)
{
    private readonly ProjectRepository _projectRepository = projectRepository;
    private readonly CustomerRepository _customerRepository = customerRepository;
    private readonly StatusTypeRepository _statusRepository = statusRepository;
    private readonly UserRepository _userRepository = userRepository;
    private readonly ProductRepository _productRepository = productRepository;

    public async Task CreateProjectAsync(ProjectRegistrationForm form)
    {
        await _projectRepository.BeginTransactionAsync();

        try
        {
            var projectEntity = ProjectFactory.Create(form);
            await _projectRepository.AddAsync(projectEntity!);

            await _projectRepository.SaveAsync();
            await _projectRepository.CommitTransactionAsync();
        }
        catch
        {
            await _projectRepository.RollbackTransactionAsync();
        }
    }
    public async Task<IEnumerable<Project?>> GetProjectsAsync()
    {
        var projectEntities = await _projectRepository.GetAsync();
        return projectEntities.Select(ProjectFactory.Create)!;
    }
    public async Task<Project?> GetProjectByIdAsync(string id)
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
            projectEntity!.Title = project.Title;
            projectEntity!.Description = project.Description;
            projectEntity!.StartDate = project.StartDate;
            projectEntity!.EndDate = project.EndDate;
            projectEntity!.CustomerId = project.CustomerId;
            CustomerEntity? customerEntity = await _customerRepository.GetAsync(x => x.Id == project.CustomerId);
            projectEntity!.Customer = customerEntity!;
            projectEntity!.StatusId = project.StatusId;
            StatusTypeEntity? statusEntity = await _statusRepository.GetAsync(x => x.Id == project.StatusId);
            projectEntity!.Status = statusEntity!;
            projectEntity!.UserId = project.UserId;
            UserEntity? userEntity = await _userRepository.GetAsync(x => x.Id == project.UserId);
            projectEntity!.User = userEntity!;
            projectEntity!.ProductId = project.ProductId;
            ProductEntity? productEntity = await _productRepository.GetAsync(x => x.Id == project.ProductId);
            projectEntity!.Product = productEntity!;
            _projectRepository.Update(projectEntity!);
            return true;
        }
        catch { return false; }
    }
    public async Task<bool> DeleteProjectAsync(string id)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
            _projectRepository.Delete(projectEntity!);
            return true;
        }
        catch { return false; }
    }
}
