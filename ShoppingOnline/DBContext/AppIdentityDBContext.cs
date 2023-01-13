using IdentityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public class AppIdentityDBContext : IdentityDbContext <AppUser>
    {
        public AppIdentityDBContext(DbContextOptions <AppIdentityDBContext> options) : base(options)
        {
        }

      // public  DbSet<AppIdentityDBContext> Identity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
