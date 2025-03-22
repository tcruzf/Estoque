using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Application.Interfaces;
using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;

namespace ControllRR.Application.Services;

public class CusomerService : ICustomerService
{

    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public CusomerService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<CustomerDto>> FindAllCustomersAsync()
    {
        await _uow.BeginTransactionAsync();
        var customerRepo = _uow.GetRepository<ICustomerRepository>();
        var obj = await customerRepo.FindAllAsync();
        return _mapper.Map<List<CustomerDto>>(obj);
    }


    public async Task InsertAsync(CustomerDto customerDto)
    {

        try
        {
            await _uow.BeginTransactionAsync();
            var customerRepo = _uow.GetRepository<ICustomerRepository>();
            var obj = _mapper.Map<Customer>(customerDto);
            await customerRepo.AddAsync(obj);
            await _uow.SaveChangesAsync();
            await _uow.CommitAsync();


        }
        catch (Exception)
        {
            await _uow.RollbackAsync(); // Rollback em caso de erro
            throw;
        }
    }

     public async Task<object> GetCustomerAsync(int start, int length, string searchValue, string sortColumn, string sortDirection)
    {
        try{
            await _uow.BeginTransactionAsync();
            var customerRepo = _uow.GetRepository<ICustomerRepository>();


        
       var result = await customerRepo.GetPaginatedCustomersAsync(start, length, searchValue, sortColumn, sortDirection);

        return new
        {
            draw = Guid.NewGuid().ToString(),
            recordsTotal = result.TotalRecords,
            recordsFiltered = result.FilteredRecords,
            data = result.Data
        };
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}