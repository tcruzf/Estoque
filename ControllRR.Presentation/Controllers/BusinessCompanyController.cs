using ControllRR.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControllRR.Presentation.Controllers;

public class BusinessCompanyController : Controller
{
    private readonly IBusinessCompanyService _businessCompanyService;

    public BusinessCompanyController(IBusinessCompanyService businessCompanyService)
    {
        _businessCompanyService = businessCompanyService;
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
            var obj = await _businessCompanyService.GetBusinessCompanyAsync(id);
            return Json(obj);
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException(ex.Message);
        }


    }
}