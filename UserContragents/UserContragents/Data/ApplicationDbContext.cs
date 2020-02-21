using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserContragents.Data
{
    public class UserContragentsDbContext : IdentityDbContext
    {
        public UserContragentsDbContext(DbContextOptions<UserContragentsDbContext> options)
            : base(options)
        {
        }
    }
}
