using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Domain.Entities;


public class ContactInfoMapping : Profile
{
    public ContactInfoMapping()
    {
        CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
    }
}