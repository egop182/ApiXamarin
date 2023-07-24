using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiForXamarin.Data.Models;

namespace ApiForXamarin.Data
{
    public class ApiForXamarinContext : DbContext
    {
        public ApiForXamarinContext (DbContextOptions<ApiForXamarinContext> options)
            : base(options)
        {
        }

        public DbSet<ApiForXamarin.Data.Models.Client> Clients { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            base.OnModelCreating(modelBuilder);
        }
    }
}
