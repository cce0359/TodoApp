using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChuckWebApp.Areas.Identity.Data;
using ChuckWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChuckWebApp.Data
{
    public class ChuckWebAppContext : IdentityDbContext<ChuckWebAppUser>
    {
        public ChuckWebAppContext(DbContextOptions<ChuckWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Todo>().ToTable("Todo");
                //.HasOne(t => t.User)
                //.WithMany(t => t.Todos)
                //.HasForeignKey(t => t.User.Id);
        }
    }
}
