using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerService.GetCustomersAsync();
        return Ok(customers);
    }
}
