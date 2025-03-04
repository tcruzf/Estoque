using ControllRR.Domain.Entities;

namespace ControllRR.Domain.Interfaces;


public interface ICustomerRepository : IRepository<Customer>
{
    Task<List<Customer>> FindAllAsync();
}