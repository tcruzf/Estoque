namespace ControllRR.Domain.Interfaces;

using ControllRR.Application.Dto;
using ControllRR.Domain.Entities.Radius;

public interface IBusinessCompanyService
{
   
    Task<BusinessCompanyDto> GetBusinessCompanyAsync(int id);
    Task<OperationResultDto> AddBusinessCompanyAsync(BusinessCompanyDto companyDto);
    Task<OperationResultDto> UpdateBusinessCompanyAsync(BusinessCompanyDto companyDto);
    Task<List<BusinessCompanyDto>> GetAllCompanyData();


   
}
