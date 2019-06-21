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

            // builder.Entity<Cliente>() 
            //         .HasKey(c => new { c.Id });

            // builder.Entity<Proyecto>()
            //         .HasKey(c => new { c.Id, c.ClienteId});

            // builder.Entity<Solicitud>()
            //         .HasKey(c => new { c.Id, c.ProyectoId, c.TecnicoId });            

            builder.Entity<Proyecto>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.ListaProyectos);

            builder.Entity<Solicitud>()
                .HasOne(s => s.Proyecto)
                .WithMany(p => p.ListaSolicitudes);

            builder.Entity<Solicitud>()
                .HasOne(s => s.Tecnico)
                .WithMany(t => t.ListaSolicitudes);

        }

        public DbSet<IgnisMercado.Models.Administrador> Administradores { get; set; }

        public DbSet<IgnisMercado.Models.Cliente> Clientes { get; set; }

        public DbSet<IgnisMercado.Models.Tecnico> Tecnicos { get; set; }

        public DbSet<IgnisMercado.Models.Solicitud> Solicitudes { get; set; }

        public DbSet<IgnisMercado.Models.Proyecto> Proyectos { get; set; }

        public new DbSet<IgnisMercado.Models.Rol> Roles { get; set; }
    }
}
