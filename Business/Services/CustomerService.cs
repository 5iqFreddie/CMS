using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;


    public async Task<IEnumerable<Customer?>> GetCustomersAsync()
    {
        var entities = await _customerRepository.GetAllAsync();

        var customers = entities.Select(CustomerFactory.Create);

        return customers;
    }


}