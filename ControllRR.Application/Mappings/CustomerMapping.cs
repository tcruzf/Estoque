using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Domain.Entities;


public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CustomerDto, Customer>()
            .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
            .ReverseMap();

        CreateMap<ContactInfoDto, ContactInfo>()
            .ReverseMap();
    }
}