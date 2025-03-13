using ControllRR.Application.Dto;

namespace ControllRR.Application.Interfaces;


public interface ISysProfilesService
{
    Task<List<SysProfilesDto>> FindAllAsync();
    Task<SysProfilesDto> FindByIdAsync(int? id);
    Task<OperationResultDto> InsertAsync(SysProfilesDto profiles);
    Task UpdateAsync(SysProfilesDto profiles);

}