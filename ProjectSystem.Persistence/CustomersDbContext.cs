using Microsoft.EntityFrameworkCore;
using ProjectSystem.Application.Interfaces;
using ProjectSystem.Domain;
using ProjectSystem.Persistence.EntityTypeConfig;


namespace ProjectSystem.Persistence
{
    public sealed class CustomersDbContext : DbContext, ICustomersDbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerViewModel> CustomerViewModel { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Order> Order { get; set; }

        public CustomersDbContext() 
        {
        }

        public CustomersDbContext(DbContextOptions<CustomersDbContext> options)
            : base(options) 
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<CustomerViewModel>(); 

            modelBuilder.ApplyConfiguration(new ProjectSystemConfig());

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.ID); 

            modelBuilder.Entity<Manager>()
                .HasKey(m => m.ID);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.ID);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Manager)
                .WithMany()
                .HasForeignKey(c => c.ManagerID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID);
            modelBuilder.Entity<Order>()
                .Property(o => o.Amount)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($@"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;");
            }
        }

    }
}
