using ControllRR.Application.Dto;
using ControllRR.Application.Interfaces;
using ControllRR.Presentation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControllRR.Presentation.Controllers;


public class CustomersController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("Customer/Serivce/Find/All")]
    public async Task<IActionResult> FindAllCustomers()
    {
        var obj = await _customerService.FindAllCustomersAsync();
        return Json(obj);
    }

    [HttpGet("Customer/s/Find/All/Show")]
    public async Task<IActionResult> GetAll()
    {
        return View();
    }

    [Authorize(Roles = "Manager, Admin")]
    [HttpPost]
    public async Task<IActionResult> GetList()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
        var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");
        var searchValue = Request.Form["search[value]"].FirstOrDefault()?.ToLower();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][data]"].FirstOrDefault();
        var sortDirection = Request.Form["order[0][dir]"].FirstOrDefault();

        var result = await _customerService.GetCustomerAsync(
            start, length, searchValue, sortColumn, sortDirection);

        return Json(result);
    }

    //
    [HttpGet]
    public async Task<IActionResult> InsertCustomer()
    {

        //return View("Views/Customers/InsertCustomer.cshtml");
        return View();
    }

    [HttpPost]
    //[Route("customers/create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> InsertCustomer(CustomerViewModel customerViewModel)
    {
        /* if(!ModelState.IsValid)
         {
             TempData["ClienteErrorMessage"] = $"Erro ao cadastrar o cliente : {customerViewModel.CustomerDto.Name}!";
             return View("Views/Customers/InsertCustomer.cshtml", customerViewModel);
         }*/
        try
        {
            await _customerService.InsertAsync(customerViewModel.CustomerDto);
            return RedirectToAction(nameof(InsertCustomer));
            //return Json(customerViewModel.CustomerDto);
        }
        catch (Exception ex)
        {
            //ModelState.AddModelError("", "Erro ao salvar: " + ex.Message);
            //return View("Views/Customers/InsertCustomer.cshtml", customerViewModel);
            return Json(ex.Message);
        }

    }
}