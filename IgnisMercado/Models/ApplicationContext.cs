using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Areas.Identity.Data;

namespace IgnisMercado.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser> 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // builder.Entity<Rol>().ToTable("Rol")
            //      .HasKey(a => new { a.Id1, a.Id2 });

        }

        public DbSet<IgnisMercado.Models.Administrador> Administrador { get; set; }

        public DbSet<IgnisMercado.Models.Cliente> Cliente { get; set; }

        public DbSet<IgnisMercado.Models.Tecnico> Tecnico { get; set; }

        public DbSet<IgnisMercado.Models.Solicitud> Solicitud { get; set; }

        public DbSet<IgnisMercado.Models.Proyecto> Proyecto { get; set; }

        public DbSet<IgnisMercado.Models.Rol> Rol { get; set; }
    }
}
