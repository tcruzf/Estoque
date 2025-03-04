using ControllRR.Application.Interfaces;
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

    [HttpGet("Customer/Service/New/Customer")]
    public async Task<IActionResult> InsertCustomer()
    {
        return View();
    }
}