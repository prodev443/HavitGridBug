using Havit.Linq;
using HavitGridBug.Models.Data;
using HavitGridBug.Models.DTOFilters;
using Microsoft.EntityFrameworkCore;

namespace HavitGridBug.Data.Services
{
    public class CustomerService(DataContext Context)
    {
        private readonly DataContext Context = Context;

        private IQueryable<Customer> Filter(DbSet<Customer> Builder, CustomerFilter filter)
        {
            IQueryable<Customer> Query = Builder
                .WhereIf(filter.Status != null, c => c.IsActive == filter.Status)
                .WhereIf(filter.Name != null, c => c.Name != null && filter.Name != null && c.Name.Contains(filter.Name));
            return Query;
        }

        public async Task<IEnumerable<Customer>> ListAsync(CustomerFilter filter, int StartIndex, CancellationToken cancellationToken, int Size = 10)
        {
            var Query = this.Filter(Context.Customers, filter);
            return await Query
                .Skip(StartIndex).Take(Size).ToListAsync();
        }

        public async Task<int> CountAsync(CustomerFilter filter, CancellationToken cancellationToken)
        {
            var Query = this.Filter(Context.Customers, filter);
            return await Query.CountAsync();
        }
    }
}
