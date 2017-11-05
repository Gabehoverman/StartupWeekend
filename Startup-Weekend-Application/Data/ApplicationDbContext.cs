using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Startup_Weekend_Application.Models;

namespace Startup_Weekend_Application.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Startup_Weekend_Application.Models.Ping> Ping { get; set; }
        public DbSet<Startup_Weekend_Application.Models.Discover> Discover { get; set; }
        public DbSet<Startup_Weekend_Application.Models.Interests> Interests { get; set; }
        public DbSet<Startup_Weekend_Application.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}
