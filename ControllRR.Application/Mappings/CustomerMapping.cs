using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Domain.Entities;


public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
    }
}