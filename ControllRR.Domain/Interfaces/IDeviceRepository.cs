using ControllRR.Domain.Entities;

namespace ControllRR.Domain.Interfaces;

public interface IDeviceRepository : IRepository<Device>
{
  Task<List<Device>> FindAllAsync();
  Task<Device> FindByIdAsync(int id);
  Task InsertAsync(Device device);
  Task UpdateAsync(Device device);

  Task<Device> GetMaintenancesAsync(int id);
  //  Task SaveChangesAsync();
  Task<(IEnumerable<object> Data, int TotalRecords, int FilteredRecords)> GetDevicesAsync(
        int start,
        int length,
        string searchValue,
        string sortColumn,
        string sortDirection);

  // Get count of devices
  Task<int> CountDevices();
  Task<List<Device>> Search(string term);

}