namespace ControllRR.Domain.Interfaces;
using ControllRR.Domain.Entities.Radius;

public interface ISysProfilesRepository : IRepository<SysProfiles>
{
    Task<List<SysProfiles>> GetAllProfilesAsync();
    Task<SysProfiles?> GetProfile(int? id);
    //Task AddProfile(Profiles profile);
    //Task<Profiles> UpdateProfile(Profiles profile);
    //Task<Profiles> DeleteProfile(int id);
}
