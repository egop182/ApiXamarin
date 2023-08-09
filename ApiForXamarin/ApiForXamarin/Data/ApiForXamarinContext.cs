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

        public DbSet<Client> Clients { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }

        //public DbSet<ApiForXamarin.Data.Models.Client> Clients { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            modelBuilder.Entity<User>().ToTable(nameof(User));


            base.OnModelCreating(modelBuilder);
        }
    }
}
