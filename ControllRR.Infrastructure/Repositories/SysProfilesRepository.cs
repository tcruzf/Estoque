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


    public async Task<SysProfiles?> GetProfile(int? id)
    {
        return await _context.SysProfiles
                        .Include(m => m.BusinessCompany)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<SysProfiles>> GetAllProfilesAsync()
    {
        return await _context.SysProfiles
                     .Include(v => v.BusinessCompany)
                     .ToListAsync();
    }

    public async Task RemoveProfileAsync(int? id)
    {
        if (id == null)
            throw new InvalidOperationException("Erro! Id não fornecido ou não contém um valor valido!");

        var profile = await _context.SysProfiles.FindAsync(id);
        if (profile == null)
        {
            throw new InvalidOperationException("Perfil não encontrado");
        }
        else
        {
            _context.SysProfiles.Remove(profile);
        }
    }

}