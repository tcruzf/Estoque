using ControllRR.Application.Dto;
using ControllRR.Application.Interfaces;
using ControllRR.Presentation.ViewModels;
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