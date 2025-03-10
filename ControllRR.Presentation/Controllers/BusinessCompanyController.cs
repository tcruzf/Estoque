using ControllRR.Application.Interfaces;
using ControllRR.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControllRR.Presentation.Controllers;

public class BusinessCompanyController : Controller
{
    private readonly IBusinessCompanyService _businessCompanyService;
    private readonly IProfilesService _profilesService;

    public BusinessCompanyController(IBusinessCompanyService businessCompanyService, IProfilesService profilesService)
    {
        _businessCompanyService = businessCompanyService;
        _profilesService = profilesService;
    }

    [HttpGet("Company/Index")]
    public async Task<IActionResult> Index()
    {
        var obj = new List<object>();
        return Json(obj);
    }

    [HttpGet("Company/{id}/Details")]
    public async Task<IActionResult> Details(int id)
    {
         
        try
        {
            
            var company = await _businessCompanyService.GetBusinessCompanyAsync(id);
            return View("Views/BusinessCompany/Company.cshtml", company);
            
        }
        catch (InvalidOperationException ex)
        {
           return Json(ex.Message);
        }//


    }
}