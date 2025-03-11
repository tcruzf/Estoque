using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControllRR.Infrastructure.Repositories;


public class BusinessCompanyRepository : BaseRepository<BusinessCompany>, IBusinessCompanyRepository
{
    public BusinessCompanyRepository(ControllRRContext context) : base(context)
    {

    }

    public async Task<List<BusinessCompany>> FindAllBusinessCompaniesAsync()
    {
       return await _context.BusinessCompanies.ToListAsync();
    }

    public async Task<BusinessCompany?> GetBusinessCompanyAsync(int id)
    {
        return await _context.BusinessCompanies
        .Include(j => j.Profiles)
        .FirstOrDefaultAsync(x => x.Id == id);
    }
}