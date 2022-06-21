using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalCounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext context;
        public CustomerController(CustomerContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll() 
            => await context.Customers.ToArrayAsync();

        [HttpPost]
        public async Task<Customer> AddCustomer([FromBody] Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }


    }
}
