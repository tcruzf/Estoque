using ControllRR.Application.Interfaces;
using ControllRR.Domain.Interfaces;
using ControllRR.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ControllRR.Presentation.Controllers;


public class SysProfilesController : Controller
{
    private readonly ISysProfilesService _profileService;
    private readonly IBusinessCompanyService _businessCompanyService;
    

    public SysProfilesController(ISysProfilesService profileService, IBusinessCompanyService businessCompanyService)
    {
        _profileService = profileService;
        _businessCompanyService = businessCompanyService;
    }

    [HttpGet("Profiles/Read/All")]
    public async Task<IActionResult> Index()
    {
        var company = await _businessCompanyService.GetAllCompanyData();
        var viewModel = new SysProfilesViewModel { BusinessCompanyDto = company };
        return View("Views/SysProfiles/Index.cshtml", viewModel);
    }
}