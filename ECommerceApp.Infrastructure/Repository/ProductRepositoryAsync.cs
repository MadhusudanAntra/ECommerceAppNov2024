using ECommerceApp.ApplicationCore.Contracts.Repository;
using ECommerceApp.ApplicationCore.Entities;
using ECommerceApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.Repository
{
    public class ProductRepositoryAsync : BaseRepositoryAsync<Product>, IProductRepositoryAsync
    {
        public ProductRepositoryAsync(EcommerceAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
