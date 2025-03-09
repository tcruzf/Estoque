using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Domain.Entities;


public class BusinessCompanyMapping : Profile
{
    public BusinessCompanyMapping()
    {
        CreateMap<BusinessCompany, BusinessCompanyDto>().ReverseMap();
    }
}