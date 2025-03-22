using ControllRR.Application.Dto;

namespace ControllRR.Application.Interfaces;


public interface ICustomerService
{
    Task<List<CustomerDto>> FindAllCustomersAsync();
    Task InsertAsync(CustomerDto customerDto);
    Task<object> GetCustomerAsync(
    int start,
    int length,
    string searchValue,
    string sortColumn,
    string sortDirection);
}