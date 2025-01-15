using ECommerceApp.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.Data
{
    public class EcommerceAppDbContext:DbContext
    {
        public EcommerceAppDbContext(DbContextOptions<EcommerceAppDbContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
