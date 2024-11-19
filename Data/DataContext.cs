using HavitGridBug.Models.Data;
using Microsoft.EntityFrameworkCore;
namespace HavitGridBug.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Customer> Customers => Set<Customer>();
    }
}
