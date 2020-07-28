using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using demoApiNetCoreMVC.Models;

namespace demoApiNetCoreMVC.Contexts
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
