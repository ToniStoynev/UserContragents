using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserContragents.Domain;

namespace UserContragents.Data
{
    public class UserContragetnsDbContext : IdentityDbContext<AppUsers, IdentityRole, string>
    {
        public DbSet<AppUsers> AppUsers { get; set; }

        public DbSet<Contragents> Contragents { get; set; }
        public UserContragetnsDbContext(DbContextOptions<UserContragetnsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUsers>()
                        .HasMany(c => c.Contragents)
                        .WithOne(u => u.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
