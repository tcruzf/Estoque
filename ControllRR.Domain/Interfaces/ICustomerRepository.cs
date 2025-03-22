using ControllRR.Domain.Entities;
using ControllRR.Domain.PaginatedResult;

namespace ControllRR.Domain.Interfaces;


public interface ICustomerRepository : IRepository<Customer>
{
    Task<List<Customer>> FindAllAsync();
    Task<(IEnumerable<object> Data, int TotalRecords, int FilteredRecords)> GetCustomerAsync(
           int start,
           int length,
           string searchValue,
           string sortColumn,
           string sortDirection);

    Task<PaginatedResult<object>> GetPaginatedCustomersAsync(int start, int length, string searchValue, string sortColumn, string sortDirection);
   
}