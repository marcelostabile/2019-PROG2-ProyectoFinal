using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Areas.Identity.Data;
using IgnisMercado.Models;

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

            builder.Entity<RelacionClienteProyecto>().ToTable("RelacionClienteProyectos");
            builder.Entity<RelacionProyectoSolicitud>().ToTable("RelacionProyectoSolicitudes");
            builder.Entity<RelacionTecnicoRol>().ToTable("RelacionTecnicoRoles");
            builder.Entity<Solicitud>().ToTable("Solicitudes");
            builder.Entity<Proyecto>().ToTable("Proyectos");
            builder.Entity<Rol>().ToTable("Roles");
            builder.Entity<Costo>().ToTable("Costos");

            // Relación Cliente:Proyecto
            builder.Entity<RelacionClienteProyecto>()
                .HasKey(cp => new { cp.ClienteId, cp.ProyectoId });

            builder.Entity<RelacionClienteProyecto>()
                .HasOne(cp => cp.Cliente)
                .WithMany(c => c.RelacionClienteProyecto)
                .HasForeignKey(cp => cp.ClienteId);

            builder.Entity<RelacionClienteProyecto>()
                .HasOne(cp => cp.Proyecto)
                .WithMany(p => p.RelacionClienteProyecto)
                .HasForeignKey(cp => cp.ProyectoId);

            // Relación Proyecto:Solicitud
            builder.Entity<RelacionProyectoSolicitud>()
                .HasKey(ps => new { ps.ProyectoId, ps.SolicitudId });

            builder.Entity<RelacionProyectoSolicitud>()
                .HasOne(ps => ps.Proyecto)
                .WithMany(p => p.RelacionProyectoSolicitud)
                .HasForeignKey(ps => ps.ProyectoId);

            builder.Entity<RelacionProyectoSolicitud>()
                .HasOne(ps => ps.Solicitud)
                .WithMany(s => s.RelacionProyectoSolicitud)
                .HasForeignKey(ps => ps.SolicitudId);

            // Relación Tecnico:Rol
            builder.Entity<RelacionTecnicoRol>()
                .HasKey(tr => new { tr.TecnicoId, tr.RolId });

            builder.Entity<RelacionTecnicoRol>()
                .HasOne(tr => tr.Tecnico)
                .WithMany(p => p.RelacionTecnicoRoles)
                .HasForeignKey(tr => tr.TecnicoId);

            builder.Entity<RelacionTecnicoRol>()
                .HasOne(tr => tr.Rol)
                .WithMany(s => s.RelacionTecnicoRoles)
                .HasForeignKey(tr => tr.RolId);

            // builder.Entity<Proyecto>()
            //     .HasOne(p => p.Cliente)
            //     .WithMany(c => c.ListaProyectos);

            // builder.Entity<Solicitud>()
            //     .HasOne(s => s.Proyecto)
            //     .WithMany(p => p.ListaSolicitudes);

            // builder.Entity<Solicitud>()
            //     .HasOne(s => s.Tecnico)
            //     .WithMany(t => t.ListaSolicitudes);

        }

        public DbSet<IgnisMercado.Models.RelacionClienteProyecto> RelacionClienteProyectos { get; set; }

        public DbSet<IgnisMercado.Models.RelacionProyectoSolicitud> RelacionProyectoSolicitudes { get; set; }

        public DbSet<IgnisMercado.Models.RelacionTecnicoRol> RelacionTecnicoRoles { get; set; }

        public DbSet<IgnisMercado.Models.Administrador> Administradores { get; set; }

        public DbSet<IgnisMercado.Models.Cliente> Clientes { get; set; }

        public DbSet<IgnisMercado.Models.Tecnico> Tecnicos { get; set; }

        public DbSet<IgnisMercado.Models.Solicitud> Solicitudes { get; set; }

        public DbSet<IgnisMercado.Models.Proyecto> Proyectos { get; set; }

        public new DbSet<IgnisMercado.Models.Rol> Roles { get; set; }

        public DbSet<IgnisMercado.Models.Costo> Costos { get; set; }

    }
}
