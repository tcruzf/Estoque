namespace ControllRR.Domain.Interfaces;
using ControllRR.Domain.Entities.Radius;

public interface IBusinessCompanyRepository : IRepository<BusinessCompany>
{
    Task<List<BusinessCompany>> FindAllBusinessCompaniesAsync();
    Task<BusinessCompany?> GetBusinessCompanyAsync(int id);
   
}
