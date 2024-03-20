using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProjectSystem.Domain;
using System.Threading;


namespace ProjectSystem.Application.Interfaces
{
    public interface ICustomersDbContext
    {
        DbSet<Customer> Customer { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
