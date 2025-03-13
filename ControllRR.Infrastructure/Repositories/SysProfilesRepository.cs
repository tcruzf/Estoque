using ControllRR.Domain.Entities.Radius;
using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data.Context;
using ControllRR.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ControllRR.Infrastructure.Repositories;


public class SysProfilesRepository : BaseRepository<SysProfiles>, ISysProfilesRepository
{
    //private readonly IUnitOfWork _uow;
    public SysProfilesRepository(ControllRRContext context) : base(context)
    {

    }


    public Task<SysProfiles> DeleteProfile(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<SysProfiles?> GetProfile(int? id)
    {
        return await  _context.SysProfiles
                        .Include(m => m.BusinessCompany)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<SysProfiles>> GetAllProfilesAsync()
    {
       return await _context.SysProfiles
                    .Include(v => v.BusinessCompany)
                    .ToListAsync();
    }
   
}