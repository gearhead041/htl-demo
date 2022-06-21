using AnimalCounting.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AnimalCounting.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1 ==1);
        }

        [Fact]
        public async Task CustomerIntegrationTest()
        {
             var configuration = new ConfigurationBuilder().
                AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            
            var context = new CustomerContext(optionsBuilder.Options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var controller = new CustomerController(context);

            await controller.AddCustomer( new Customer { Name = "Foobar" });
            
            var result =  (await controller.GetAll()).ToArray();
            Assert.Single(result);
            Assert.Equal("Foobar", result[0].Name);


        }

    }
}