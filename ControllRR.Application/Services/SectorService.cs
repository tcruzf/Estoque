using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Application.Interfaces;
using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;

namespace ControllRR.Application.Services;

public class SectorService : ISectorService
{
    
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;
    public SectorService(
        ISectorRepository sectorRepository,
        IMapper mapper,
        IUnitOfWork uow
        )
    {
      
        _mapper = mapper;
        _uow = uow;
    }

    public async Task<List<SectorDto>> FindAllAsync()
    {
        await _uow.BeginTransactionAsync();
        var sectorRepo = _uow.GetRepository<ISectorRepository>();
        //
        var sectors = await sectorRepo.FindAllAsync();
        return _mapper.Map<List<SectorDto>>(sectors);

    }

    public async Task InsertAsync(SectorDto sectorDto)
    {
        await _uow.BeginTransactionAsync();
        var sector = _mapper.Map<Sector>(sectorDto);
        var sectorRepo = _uow.GetRepository<ISectorRepository>();
        await sectorRepo.InsertAsync(sector);
        await _uow.SaveChangesAsync();
        await _uow.CommitAsync();


    }

    public async Task<SectorDto> FindByIdAsync(int id)
    {
        await _uow.BeginTransactionAsync();
        var sectorRepo = _uow.GetRepository<ISectorRepository>();
        //
        var sector = await sectorRepo.FindByIdAsync(id);
        return _mapper.Map<SectorDto>(sector);

    }

    public async Task<object> GetSectorAsync(int start, int length, string searchValue, string sortColumn, string sortDirection)
    {
        try{
            await _uow.BeginTransactionAsync();
            var sectorRepo = _uow.GetRepository<ISectorRepository>();


        
        (IEnumerable<object> data, int totalRecords, int filteredRecords) =
              await sectorRepo.GetSectorAsync(start, length, searchValue, sortColumn, sortDirection);

        return new
        {
            draw = Guid.NewGuid().ToString(),
            recordsTotal = totalRecords,
            recordsFiltered = filteredRecords,
            data
        };
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateAsync(SectorDto sectorDto)
    {
        await _uow.BeginTransactionAsync();
        var sector = _mapper.Map<Sector>(sectorDto);
        var sectorRepo = _uow.GetRepository<ISectorRepository>();
        await sectorRepo.UpdateAsync(sector);
        await _uow.SaveChangesAsync();
        await _uow.CommitAsync();

    }



}