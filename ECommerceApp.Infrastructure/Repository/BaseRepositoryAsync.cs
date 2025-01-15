using ECommerceApp.ApplicationCore.Contracts.Repository;
using ECommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly EcommerceAppDbContext dbContext;

        public BaseRepositoryAsync(EcommerceAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> DeleteAsync(int id)
        {
           var t = await GetByIdAsync(id);
            dbContext.Remove(t);
           return await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Search(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
           return await dbContext.SaveChangesAsync();
        }
    }
}
