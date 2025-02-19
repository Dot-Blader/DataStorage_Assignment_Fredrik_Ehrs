using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;

public class StatusTypeService(StatusTypeRepository statusTypeRepository)
{
    private readonly StatusTypeRepository _statusTypeRepository = statusTypeRepository;

    public async Task CreateStatusTypeAsync(StatusTypeRegForm form)
    {
        var statusTypeEntity = StatusTypeFactory.Create(form);
        await _statusTypeRepository.AddAsync(statusTypeEntity!);
    }
    public async Task<IEnumerable<StatusType?>> GetStatusTypesAsync()
    {
        var statusTypeEntities = await _statusTypeRepository.GetAsync();
        return statusTypeEntities.Select(StatusTypeFactory.Create)!;
    }
    public async Task<StatusType?> GetStatusTypeByIdAsync(int id)
    {
        var statusTypeEntity = await _statusTypeRepository.GetAsync(x => x.Id == id);
        return StatusTypeFactory.Create(statusTypeEntity!);
    }
    public async Task<StatusType?> GetStatusTypeByStatusNameAsync(string name)
    {
        var statusTypeEntity = await _statusTypeRepository.GetAsync(x => x.StatusName == name);
        return StatusTypeFactory.Create(statusTypeEntity!);
    }
    public async Task<bool> UpdateStatusTypeAsync(StatusType statusType)
    {
        try
        {
            var statusTypeEntity = await _statusTypeRepository.GetAsync(x => x.Id == statusType.Id);
            statusTypeEntity.StatusName = statusType.StatusName;
            await _statusTypeRepository.UpdateAsync(statusTypeEntity!);
            return true;
        }
        catch { return false; }
    }
    public async Task<bool> DeleteStatusTypeAsync(int id)
    {
        try
        {
            var statusTypeEntity = await _statusTypeRepository.GetAsync(x => x.Id == id);
            await _statusTypeRepository.DeleteAsync(statusTypeEntity!);
            return true;
        }
        catch { return false; }
    }
}
