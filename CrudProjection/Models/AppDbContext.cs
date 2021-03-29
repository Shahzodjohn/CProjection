using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProjection.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Odam> Odamon { get; set; }
        public AppDbContext(DbContextOptions options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        
    }
}
