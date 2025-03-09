using System.Data;
using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Domain.Interfaces;

namespace ControllRR.Application.Interfaces;


public class BusinessCompanyService : IBusinessCompanyService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public BusinessCompanyService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<BusinessCompanyDto>> GetBusinessCompanyAsync(int id)
    {

        await _uow.BeginTransactionAsync();
        var businessRepo = _uow.GetRepository<IBusinessCompanyRepository>();
        var result = await businessRepo.GetBusinessCompanyAsync(id);
        return _mapper.Map<List<BusinessCompanyDto>>(result);
    }

    /// <summary>
    /// Cria um novo registro de uma empresa
    /// </summary>
    /// <param name="companyDto"></param>
    /// <returns>Um conjunto de valores do tipo OperationResultDto false ou true</returns>
    public async Task<OperationResultDto> AddBusinessCompanyAsync(BusinessCompanyDto companyDto)
    {
        try
        {
            var company = _mapper.Map<BusinessCompany>(companyDto);
            await _uow.BeginTransactionAsync();
            var companyRepo = _uow.GetRepository<IBusinessCompanyRepository>();
            await companyRepo.AddAsync(company);
            return new OperationResultDto { Success = false, AlertScript = "Operação realizada com sucesso" };
        }
        catch (DBConcurrencyException ex)
        {
            return new OperationResultDto { Success = false, AlertScript = ex.Message };
            //await _uow.RollbackAsync();
        }

    }

    public Task<OperationResultDto> UpdateBusinessCompanyAsync(BusinessCompanyDto companyDto)
    {
        throw new NotImplementedException();
    }


}