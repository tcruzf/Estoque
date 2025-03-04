using ControllRR.Application.Dto;

namespace ControllRR.Application.Interfaces;


public interface ICustomerService
{
    Task<List<CustomerDto>> FindAllCustomersAsync();
}