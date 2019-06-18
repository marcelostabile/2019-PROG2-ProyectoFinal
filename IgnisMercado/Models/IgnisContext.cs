using Microsoft.EntityFrameworkCore;

namespace IgnisMercado.Models
{
    public class IgnisContext : DbContext
    {
        public IgnisContext (DbContextOptions<IgnisContext> options)
            : base(options)
        {
        }

        public DbSet<IgnisMercado.Administrador> Administradores { get; set; }

        public DbSet<IgnisMercado.Cliente> Clientes { get; set; }

        public DbSet<IgnisMercado.Tecnico> Tecnicos { get; set; }

        public DbSet<IgnisMercado.Solicitud> Solicitudes { get; set; }

        public DbSet<IgnisMercado.Proyecto> Proyectos { get; set; }

        public DbSet<IgnisMercado.Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<TecnicoSolicitud>().ToTable("TecnicoSolicitud")
            //     .HasKey(a => new { a.tecnicoID, a.solicitudID });
        }

    }
}