using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;
using ControllRR.Domain.PaginatedResult;
using ControllRR.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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


    public async Task<(IEnumerable<object> Data, int TotalRecords, int FilteredRecords)> GetCustomerAsync(
     int start,
     int length,
     string searchValue,
     string sortColumn,
     string sortDirection)
    {
        var query = _context.Customers
            .Include(x => x.ContactInfo)
            .AsQueryable();

        // Filtragem
        if (!string.IsNullOrEmpty(searchValue))
        {   //Gambiarra para poder fazer uma porrada de tentativa de pegar um ou outro valor(não vou explicar, tô com a cabeça e o estomago doendo e sem paciencia!)
            query = query.Where(x =>
                (x.Name != null && x.Name.ToLower().Contains(searchValue)) ||
                (x.CPF_CNPJ != null && x.CPF_CNPJ.ToLower().Contains(searchValue)) ||
                (x.ContactInfo.Street != null && x.ContactInfo.Street.ToLower().Contains(searchValue)) ||
                (x.ContactInfo.Email != null && x.ContactInfo.Email.ToLower().Contains(searchValue)) ||
                (x.ContactInfo.Phone != null && x.ContactInfo.Phone.ToLower().Contains(searchValue)) ||
                (x.ContactInfo.CEP != null && x.ContactInfo.CEP.ToLower().Contains(searchValue)) ||
                (x.ContactInfo.WhattsApp != null && x.ContactInfo.WhattsApp.ToLower().Contains(searchValue)));
        }

        // Contagem após o filtro
        var filteredCount = await query.CountAsync();

        // Ordenação
        if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection))
        {
            query = query.OrderBy($"{sortColumn} {sortDirection}");
        }
        else
        {
            query = query.OrderBy(x => x.Id);
        }

        // Paginação
        var data = await query
            .Skip(start)
            .Take(length)
            .Select(x => new
            {
                Id = x.Id,
                Cep = x.ContactInfo.CEP,
                Street = x.ContactInfo.Street,
                CPF_CNPJ = x.CPF_CNPJ,
                Name = x.Name,
                WhattsApp = x.ContactInfo.WhattsApp,
                Phone = x.ContactInfo.Phone

            })
            .ToListAsync();

        var totalRecords = await _context.Customers.CountAsync();

        return (data, totalRecords, filteredCount);
    }

    public async Task<PaginatedResult<object>> GetPaginatedCustomersAsync(
      int start,
      int length,
      string searchValue,
      string sortColumn,
      string sortDirection)
    {

        var query = BuildCustomerQuery(searchValue);
        var orderedQuery = ApplySorting(query, sortColumn, sortDirection);

        return new PaginatedResult<object>
        {

            Data = await orderedQuery
            .Skip(start)
            .Take(length)
            .Select(x => new
            {
                Id = x.Id,
                Cep = x.ContactInfo.CEP,
                Street = x.ContactInfo.Street,
                CPF_CNPJ = x.CPF_CNPJ,
                Name = x.Name,
                WhattsApp = x.ContactInfo.WhattsApp,
                Phone = x.ContactInfo.Phone
            })
            .ToListAsync(),
            TotalRecords = await _context.Customers.CountAsync(),
            FilteredRecords = await query.CountAsync()
        };


    }

    #region Private Helpers
    private IQueryable<Customer> BuildCustomerQuery(string searchValue)
    {

        var query = _context.Customers
            .Include(x => x.ContactInfo)
            .AsQueryable();

        // Filtragem 
        if (!string.IsNullOrEmpty(searchValue))
        {   //Gambiarra para poder fazer uma porrada de tentativa de pegar um ou outro valor(não vou explicar, tô com a cabeça e o estomago doendo e sem paciencia!)
            query = query.Where(x =>
                (x.Name != null && x.Name.ToLower().Contains(searchValue)) ||
                (x.CPF_CNPJ != null && x.CPF_CNPJ.ToLower().Contains(searchValue)) ||
                (x.ContactInfo.Street != null && x.ContactInfo.Street.ToLower().Contains(searchValue)) ||
                (x.ContactInfo.Email != null && x.ContactInfo.Email.ToLower().Contains(searchValue)) ||
                (x.ContactInfo.Phone != null && x.ContactInfo.Phone.ToLower().Contains(searchValue)) ||
                (x.ContactInfo.CEP != null && x.ContactInfo.CEP.ToLower().Contains(searchValue)) ||
                (x.ContactInfo.WhattsApp != null && x.ContactInfo.WhattsApp.ToLower().Contains(searchValue)));
        }
        return query;
    }

    private IQueryable<Customer> ApplySorting(IQueryable<Customer> query, string sortColumn, string sortDirection)
    {
        if (sortColumn == "street")
        {
            sortColumn = "ContactInfo.Street";//
        }
        else if(sortColumn == "phone")
        {
            sortColumn = "ContactInfo.Phone";
        }
        else if(sortColumn == "whattsApp")
        {
            sortColumn = "ContactInfo.WhattsApp";
        }

        return !string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection)
        ? query.OrderBy($"{sortColumn} {sortDirection}")
        : query = query.OrderBy(x => x.Id);
    }
    #endregion

}