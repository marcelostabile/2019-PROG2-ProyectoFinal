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

            // Relación Entidad:Tabla.
            builder.Entity<RelacionClienteProyecto>().ToTable("RelacionClienteProyectos");
            builder.Entity<RelacionProyectoSolicitud>().ToTable("RelacionProyectoSolicitudes");
            builder.Entity<RelacionTecnicoSolicitud>().ToTable("RelacionTecnicoSolicitudes");
            builder.Entity<RelacionTecnicoRol>().ToTable("RelacionTecnicoRoles");
            builder.Entity<Solicitud>().ToTable("Solicitudes");
            builder.Entity<Proyecto>().ToTable("Proyectos");
            builder.Entity<Rol>().ToTable("Roles");
            builder.Entity<Costo>().ToTable("Costos");
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers");

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
                .WithMany(p => p.RelacionTecnicoRol)
                .HasForeignKey(tr => tr.TecnicoId);

            builder.Entity<RelacionTecnicoRol>()
                .HasOne(tr => tr.Rol)
                .WithMany(s => s.RelacionTecnicoRol)
                .HasForeignKey(tr => tr.RolId);

            // Relación Tecnico:Solicitud

            builder.Entity<RelacionTecnicoSolicitud>()
                .HasKey(r => new { r.TecnicoId, r.SolicitudId });

            builder.Entity<RelacionTecnicoSolicitud>()
                .HasOne(r => r.Tecnico)
                .WithMany(t => t.RelacionTecnicoSolicitud)
                .HasForeignKey(r => r.TecnicoId);

            builder.Entity<RelacionTecnicoSolicitud>()
                .HasOne(r => r.Solicitud)
                .WithMany(s => s.RelacionTecnicoSolicitud)
                .HasForeignKey(r => r.SolicitudId);
        }

        public DbSet<IgnisMercado.Models.RelacionClienteProyecto> RelacionClienteProyectos { get; set; }

        public DbSet<IgnisMercado.Models.RelacionProyectoSolicitud> RelacionProyectoSolicitudes { get; set; }

        public DbSet<IgnisMercado.Models.RelacionTecnicoRol> RelacionTecnicoRoles { get; set; }

        public DbSet<IgnisMercado.Models.RelacionTecnicoSolicitud> RelacionTecnicoSolicitudes { get; set; }

        public DbSet<IgnisMercado.Areas.Identity.Data.ApplicationUser> Tecnicos { get; set; }

        public DbSet<IgnisMercado.Models.Solicitud> Solicitudes { get; set; }

        public DbSet<IgnisMercado.Models.Proyecto> Proyectos { get; set; }

        public new DbSet<IgnisMercado.Models.Rol> Roles { get; set; }

        public DbSet<IgnisMercado.Models.Costo> Costos { get; set; }
    }
}
