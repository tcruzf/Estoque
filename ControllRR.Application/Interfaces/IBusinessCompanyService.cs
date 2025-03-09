namespace ControllRR.Domain.Interfaces;

using ControllRR.Application.Dto;
using ControllRR.Domain.Entities.Radius;

public interface IBusinessCompanyService
{
   
    Task<List<BusinessCompanyDto>> GetBusinessCompanyAsync(int id);
    Task<OperationResultDto> AddBusinessCompanyAsync(BusinessCompanyDto companyDto);
    Task<OperationResultDto> UpdateBusinessCompanyAsync(BusinessCompanyDto companyDto);
   
}
