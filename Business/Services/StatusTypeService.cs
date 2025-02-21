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
        await _statusTypeRepository.BeginTransactionAsync();

        try
        {
            var statusTypeEntity = StatusTypeFactory.Create(form);
            await _statusTypeRepository.AddAsync(statusTypeEntity!);

            await _statusTypeRepository.SaveAsync();
            await _statusTypeRepository.CommitTransactionAsync();
        }
        catch
        {
            await _statusTypeRepository.RollbackTransactionAsync();
        }
    }
    public async Task<IEnumerable<StatusType?>> GetStatusTypesAsync()
    {
        var statusTypeEntities = await _statusTypeRepository.GetAsync();
        return statusTypeEntities.Select(StatusTypeFactory.Create)!;
    }
    public async Task<StatusType?> GetStatusTypeByIdAsync(string id)
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
            statusTypeEntity!.StatusName = statusType.StatusName;
            _statusTypeRepository.Update(statusTypeEntity!);
            return true;
        }
        catch { return false; }
    }
    public async Task<bool> DeleteStatusTypeAsync(string id)
    {
        try
        {
            var statusTypeEntity = await _statusTypeRepository.GetAsync(x => x.Id == id);
            _statusTypeRepository.Delete(statusTypeEntity!);
            return true;
        }
        catch { return false; }
    }
}
