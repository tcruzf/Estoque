using ControllRR.Application.Dto;
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

    [HttpGet("Company/SetupCompany")]
    public async Task<IActionResult> SetupCompany()
    {
        //var obj = new List<object>();
        return View();
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

    [HttpGet("Company/{id}/EditCompany")]
    public async Task<IActionResult> Edit(int id)
    {

        try
        {

            var company = await _businessCompanyService.GetBusinessCompanyAsync(id);
            return View("Views/BusinessCompany/EditCompany.cshtml", company);

        }
        catch (InvalidOperationException ex)
        {
            return Json(ex.Message);
        }//
    }





    [HttpGet("Company/HomePage/ShowCompany")]
    public async Task<IActionResult> HomePage()
    {
        var company = await _businessCompanyService.GetAllCompanyData();
        return View("Views/BusinessCompany/HomePage.cshtml", company);
        //return Json(company);
    }
}