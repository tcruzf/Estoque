using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Application.Interfaces;
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
}