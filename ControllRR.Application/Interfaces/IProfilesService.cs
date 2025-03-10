using ControllRR.Application.Dto;

namespace ControllRR.Application.Interfaces;


public interface IProfilesService
{
    Task<List<ProfilesDto>> FindAllAsync();
    Task<ProfilesDto> FindByIdAsync(int id);
    Task InsertAsync(ProfilesDto profiles);
    Task UpdateAsync(ProfilesDto profiles);

}