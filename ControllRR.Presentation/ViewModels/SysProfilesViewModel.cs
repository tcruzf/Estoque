using ControllRR.Application.Dto;
using ControllRR.Domain.Entities;

namespace ControllRR.Presentation.ViewModels;


public class SysProfilesViewModel //
{
    public SysProfilesDto? SysProfilesDto {get; set;}
    public ICollection<BusinessCompanyDto>? BusinessCompanyDto { get; set; }
    
}