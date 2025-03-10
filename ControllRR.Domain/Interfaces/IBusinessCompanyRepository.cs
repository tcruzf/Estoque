namespace ControllRR.Domain.Interfaces;
using ControllRR.Domain.Entities.Radius;

public interface IBusinessCompanyRepository : IRepository<BusinessCompany>
{
    Task<IEnumerable<BusinessCompany>> FindAllBusinessCompaniesAsync();
    Task<BusinessCompany?> GetBusinessCompanyAsync(int id);
   
}
