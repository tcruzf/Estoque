using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data.Context;
using ControllRR.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ControllRR.Infrastructure.Repositories;


public class ProfilesRepository : BaseRepository<Profiles>, IProfilesRepository
{
    //private readonly IUnitOfWork _uow;
    public ProfilesRepository(ControllRRContext context) : base(context)
    {

    }

    public async Task AddProfile(Profiles profile)
    {

        await _context.Profiles.AddAsync(profile);

    }

    public Task<Profiles> DeleteProfile(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Profiles?> GetProfile(int id)
    {
        return await  _context.Profiles
                        .Include(m => m.BusinessCompany)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Profiles>> GetAllProfilesAsync()
    {
       return await _context.Profiles
                    .Include(v => v.BusinessCompany)
                    .ToListAsync();
    }

    public Task<Profiles> UpdateProfile(Profiles profile)
    {
        throw new NotImplementedException();
    }
}