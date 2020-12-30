using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCWebApp.Models;
using MVCWebApp.Models.Views;

namespace MVCWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MVCWebApp.Models.Person> Person { get; set; }
        public DbSet<MVCWebApp.Models.PAddress> PAddress { get; set; }
        public DbSet<MVCWebApp.Models.Views.PersonAddressview> PersonAddressview { get; set; }
    }
}
