using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data.Context;

namespace ControllRR.Infrastructure.Repositories;


public class ProfilesRepository : BaseRepository<Profiles>, IProfilesRepository
{
    //private readonly IUnitOfWork _uow;
    public ProfilesRepository(ControllRRContext context) : base(context)
    {
        
    }

    public Task<Profiles> AddProfile(Profiles profile)
    {
        throw new NotImplementedException();
    }

    public Task<Profiles> DeleteProfile(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Profiles> GetProfile(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Profiles>> GetProfiles()
    {
        throw new NotImplementedException();
    }

    public Task<Profiles> UpdateProfile(Profiles profile)
    {
        throw new NotImplementedException();
    }
}