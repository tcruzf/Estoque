using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Domain.Entities;


public class ProfilesMapping : Profile
{
    public ProfilesMapping()
    {
        CreateMap<Profiles, ProfilesDto>().ReverseMap();
    }
}