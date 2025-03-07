namespace ControllRR.Domain.Interfaces;
using ControllRR.Domain.Entities.Radius;

public interface IProfilesRepository : IRepository<Profiles>
{
    Task<IEnumerable<Profiles>> GetProfiles();
    Task<Profiles> GetProfile(int id);
    Task<Profiles> AddProfile(Profiles profile);
    Task<Profiles> UpdateProfile(Profiles profile);
    Task<Profiles> DeleteProfile(int id);
}
