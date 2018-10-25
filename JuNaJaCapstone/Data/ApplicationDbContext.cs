using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JuNaJaCapstone.Models;

namespace JuNaJaCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JuNaJaCapstone.Models.Property> Property { get; set; }
        public DbSet<JuNaJaCapstone.Models.PropertyNote> PropertyNote { get; set; }
        public DbSet<JuNaJaCapstone.Models.PropertyImage> PropertyImage { get; set; }
    }
}
