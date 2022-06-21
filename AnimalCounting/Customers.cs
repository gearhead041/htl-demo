using Microsoft.EntityFrameworkCore;

namespace AnimalCounting
{
    public class Customer
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }

    public class CustomerContext: DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}
