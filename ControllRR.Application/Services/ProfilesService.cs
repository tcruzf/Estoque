using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Application.Interfaces;
using ControllRR.Domain.Interfaces;

namespace ControllRR.Application.Services;

public class ProfilesService : IProfilesService
{

    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public ProfilesService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<ProfilesDto>> FindAllAsync()
    {
        try
        {

            await _uow.BeginTransactionAsync();
            var profileRepo = _uow.GetRepository<IProfilesRepository>();
            var obj = await profileRepo.GetAllProfilesAsync();
            return _mapper.Map<List<ProfilesDto>>(obj);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<ProfilesDto> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(ProfilesDto profiles)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ProfilesDto profiles)
    {
        throw new NotImplementedException();
    }
}