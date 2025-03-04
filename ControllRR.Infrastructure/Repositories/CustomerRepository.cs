using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControllRR.Infrastructure.Repositories;


public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ControllRRContext context) : base(context)
    {
        
    }

    public async Task<List<Customer>> FindAllAsync()
    {
        var obj = await _context.Customers.ToListAsync();
        return obj;
    }

}