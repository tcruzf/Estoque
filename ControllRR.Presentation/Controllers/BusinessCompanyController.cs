/*
 Estou fazendo alguns testes com rotas personalizadas neste controller.
  No fim, todos os outros requisitos estão sendo seguidos corretamente, somente a rota através do metodo assinado [HttpGet("Nome/da/Rota/")] ou
  [HttpGet("Nome/da/rota/{id})] que estão presentes. O motivo: necessidade de entender melhor algumas rotas.
  Até havia feito algo no controller dos "Devices", mas achei
  por bem, implementar em um outro controller e fazer alguns testes.
  No fim, todo o projeto estará padronizado.


*/
using ControllRR.Application.Dto;
using ControllRR.Application.Interfaces;
using ControllRR.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControllRR.Presentation.Controllers;

public class BusinessCompanyController : Controller
{
    private readonly IBusinessCompanyService _businessCompanyService;
    private readonly ISysProfilesService _profilesService;

    public BusinessCompanyController(IBusinessCompanyService businessCompanyService, ISysProfilesService profilesService)
    {
        _businessCompanyService = businessCompanyService;
        _profilesService = profilesService;
    }

    [HttpGet("Company/SetupCompany")]
    [Authorize(Roles = "Manager, Admin")]
    public async Task<IActionResult> SetupCompany()
    {
        //var obj = new List<object>();
        return View();
    }

    [HttpGet("Company/{id}/Details")]
    [Authorize(Roles = "Manager, Admin")]
    public async Task<IActionResult> Details(int id)
    {

        try
        {

            TempData["CompanyAlertMessage"] = "ATENÇÃO: Você está área de edição de empresas.";
            var company = await _businessCompanyService.GetBusinessCompanyAsync(id);
            return View("Views/BusinessCompany/SetupCompany.cshtml", company);

        }
        catch (InvalidOperationException ex)
        {
            return Json(ex.Message);
        }//
    }

    [HttpGet("Company/{id}/EditCompany")]
    [Authorize(Roles = "Manager, Admin")]
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
    [Authorize(Roles = "Manager, Admin")]
    public async Task<IActionResult> HomePage()
    {
        var company = await _businessCompanyService.GetAllCompanyData();
        return View("Views/BusinessCompany/Company.cshtml", company);
        //return Json(company);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Manager, Admin")]
    public async Task<IActionResult> UpdateCompany(BusinessCompanyDto businessCompanyDto)
    {
        try
        {
            var result = await _businessCompanyService.UpdateBusinessCompanyAsync(businessCompanyDto);
            TempData["ListCompanySucessMessage"] = "ATENÇÃO: Alterações realizadas na empresa foram salvas!!!";
            return RedirectToAction(nameof(HomePage));
        }
        catch (Exception ex)
        {
            TempData["ListCompanyErrorMessage"] = "ATENÇÃO: Não foi possivel realizar alterações na Empresa!!!";
            throw new Exception(ex.Message);
        }


    }
}