using Microsoft.EntityFrameworkCore;
using ProjectSystem.Domain;
using ProjectSystem.Persistence;

namespace CustomersProjectTest.Common
{
    internal class CustomersFactory
    {
        public static CustomersDbContext CreateDbContext()
        {

            var options = new DbContextOptionsBuilder<CustomersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = new CustomersDbContext(options);

            dbContext.Database.EnsureCreated();

            dbContext.Customer.AddRange(new List<Customer>
        {
            new Customer { ID = 1, Name = "Customer 1", ManagerID = 1 },
            new Customer { ID = 2, Name = "Customer 2", ManagerID = 2 },
            new Customer { ID = 3, Name = "Customer 3", ManagerID = 1 }
        });
            dbContext.Manager.AddRange(new List<Manager>
        {
            new Manager { ID = 1, Name = "Manager 1" },
            new Manager { ID = 2, Name = "Manager 2" }
        });
            dbContext.Order.AddRange(new List<Order>
        {
            new Order { ID = 1, Date = new DateTime(2024, 3, 10), Amount = 100, CustomerID = 1 },
            new Order { ID = 2, Date = new DateTime(2024, 3, 11), Amount = 200, CustomerID = 2 },
            new Order { ID = 3, Date = new DateTime(2024, 3, 12), Amount = 300, CustomerID = 3 }
        });

            dbContext.SaveChanges();
            return dbContext;
        }

        public static void Destroy(CustomersDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
