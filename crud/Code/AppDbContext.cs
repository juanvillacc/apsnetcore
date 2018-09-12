using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace crud.Code
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base (options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
