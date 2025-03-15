using ControllRR.Application.Dto;

namespace ControllRR.Application.Interfaces;


public interface ISysProfilesService
{
    Task<List<SysProfilesDto>> FindAllAsync();
    Task<SysProfilesDto> FindByIdAsync(int? id);
    Task<OperationResultDto> InsertAsync(SysProfilesDto profiles);
    Task<OperationResultDto> UpdateAsync(SysProfilesDto profiles);
     Task<OperationResultDto> RemoveAsync(int? id);

}