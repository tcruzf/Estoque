namespace ControllRR.Domain.Interfaces;
using ControllRR.Domain.Entities.Radius;

public interface IBusinessCompanyRepository : IRepository<BusinessCompany>
{
    Task<IEnumerable<BusinessCompany>> FindAllBusinessCompaniesAsync();
    Task<BusinessCompany?> GetBusinessCompanyAsync(int id);
   /* Task<BusinessCompany> AddBusinessCompanyAsync(BusinessCompany profile);
    Task<BusinessCompany> UpdateProfile(BusinessCompany profile);
    Task<BusinessCompany> DeleteProfile(int id);*/
}
