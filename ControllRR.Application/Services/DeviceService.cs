using ControllRR.Application.Interfaces;
using ControllRR.Domain.Entities;
namespace ControllRR.Application.Services;

using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Domain.Interfaces;

public class DeviceService : IDeviceService
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;

    public DeviceService(IDeviceRepository deviceRepository, IMapper mapper, IUnitOfWork uow)
    {
        _deviceRepository = deviceRepository;
        _mapper = mapper;
        _uow = uow;
    }
    public async Task<List<DeviceDto>> FindAllAsync()
    {
        var devices = await _deviceRepository.FindAllAsync();
        return _mapper.Map<List<DeviceDto>>(devices);
    }

    public async Task<DeviceDto> FindByIdAsync(int id)
    {
        var devices = await _deviceRepository.FindByIdAsync(id);
        return _mapper.Map<DeviceDto>(devices);
    }

    public async Task<DeviceDto> GetMaintenancesAsync(int id)
    {
        
        var deviceRepo = _uow.GetRepository<IDeviceRepository>();
        var device = await deviceRepo.GetMaintenancesAsync(id);
        return _mapper.Map<DeviceDto>(device);
    }

    public async Task InsertAsync(DeviceDto deviceDto)
    {
        await _uow.BeginTransactionAsync();
        var deviceRepo = _uow.GetRepository<IDeviceRepository>();
        var device = _mapper.Map<Device>(deviceDto);
        await deviceRepo.InsertAsync(device);
        await _uow.SaveChangesAsync();
        await _uow.CommitAsync();

    }

    public async Task UpdateAsync(DeviceDto deviceDto)
    {
        await _uow.BeginTransactionAsync();
        var device = _mapper.Map<Device>(deviceDto);
        var deviceRepo = _uow.GetRepository<IDeviceRepository>();
        await deviceRepo.UpdateAsync(device);
        await _uow.SaveChangesAsync();
        await _uow.CommitAsync();
    }


    //
    public async Task<object> GetDeviceAsync(int start, int length, string searchValue, string sortColumn, string sortDirection)
    {
        (IEnumerable<object> data, int totalRecords, int filteredRecords) =
              await _deviceRepository.GetDevicesAsync(start, length, searchValue, sortColumn, sortDirection);

        return new
        {
            draw = Guid.NewGuid().ToString(),
            recordsTotal = totalRecords,
            recordsFiltered = filteredRecords,
            data
        };
    }

    public async Task<int> CountDevices()
    {
        return await _deviceRepository.CountDevices();
    }

    public async Task<List<DeviceDto>> Search(string term)
    {
        await _uow.BeginTransactionAsync();
        var deviceRepo = _uow.GetRepository<IDeviceRepository>();
        var devices = await deviceRepo.SearchAsync(
                term,
                additionalFilter: null, //  filtro adicional 
                includes:null,
                x => x.Id.ToString(),
                x => x.SerialNumber,
                x => x.Type,
                x => x.Identifier,
                x => x.Model
            );

        return _mapper.Map<List<DeviceDto>>(devices);
    }
}