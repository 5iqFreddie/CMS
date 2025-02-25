using Business.Models;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer?>> GetCustomersAsync();
    }
}