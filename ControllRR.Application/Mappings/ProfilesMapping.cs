using AutoMapper;
using ControllRR.Application.Dto;
using ControllRR.Domain.Entities.Radius;


public class SysProfilesMapping : Profile
{
    public SysProfilesMapping()
    {
        CreateMap<SysProfiles, SysProfilesDto>().ReverseMap();
    }
}