
using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Application.Interfaces;
using ControllRR.Domain.Entities.Radius;
using ControllRR.Domain.Interfaces;
namespace ControllRR.Application.Services;

public class SysProfilesService : ISysProfilesService
{

    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public SysProfilesService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<SysProfilesDto>> FindAllAsync()
    {
        try
        {

            await _uow.BeginTransactionAsync();
            var profileRepo = _uow.GetRepository<ISysProfilesRepository>();
            var obj = await profileRepo.GetAllProfilesAsync();
            return _mapper.Map<List<SysProfilesDto>>(obj);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<SysProfilesDto> FindByIdAsync(int? id)
    {
        if (id == null)
            throw new Exception("Id não contém um valor!");
        var profileRepo = _uow.GetRepository<ISysProfilesRepository>();
        var profile = await profileRepo.GetProfile(id);
        return _mapper.Map<SysProfilesDto>(profile);

    }

    public async Task<OperationResultDto> InsertAsync(SysProfilesDto profiles)
    {
        var result = new OperationResultDto { Success = true };
        if (profiles == null)
            return new OperationResultDto { Success = false, Message = "Informações Invalidas!" };
        try
        {

            await _uow.BeginTransactionAsync();
            var profileRepo = _uow.GetRepository<ISysProfilesRepository>();
            var newProfile = _mapper.Map<SysProfiles>(profiles);         
            await profileRepo.AddAsync(newProfile);
            await _uow.SaveChangesAsync();
            await _uow.CommitAsync();
            return new OperationResultDto 
            {
                Success = true,
                Message = "Inserido com Sucesso!"
            };


        }
        catch (Exception ex)
        {
            await _uow.RollbackAsync();
            return new OperationResultDto
            {
                Success = false,
                Message = ex.Message
            };
        }



    }

    private string GenerateErrorScript(string ex)
    {
        return $@"
        Swal.fire({{
            icon: 'error',
            title: 'Erro no Perfil!',
            html: `Não foi possivel inserir o perfil. Erro: <b>{ex}</b> ! <br> 
                   `,
            footer: '<a href='/Stocks/SearchProduct'>Verifique os perfis</a>'
        }});";
    }

    public Task UpdateAsync(SysProfilesDto profiles)
    {
       throw new NotImplementedException();
    }
}