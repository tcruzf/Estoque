namespace ControllRR.Domain.Interfaces;
using ControllRR.Domain.Entities.Radius;

public interface IProfilesRepository : IRepository<Profiles>
{
    Task<List<Profiles>> GetAllProfilesAsync();
    Task<Profiles?> GetProfile(int id);
    Task AddProfile(Profiles profile);
    Task<Profiles> UpdateProfile(Profiles profile);
    Task<Profiles> DeleteProfile(int id);
}
