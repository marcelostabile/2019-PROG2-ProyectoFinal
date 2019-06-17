using Microsoft.EntityFrameworkCore;

namespace RazorPagesIgnis.Models
{
    public class IgnisContext : DbContext
    {
        public IgnisContext (DbContextOptions<IgnisContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesIgnis.Administrador> Administradores { get; set; }

        public DbSet<RazorPagesIgnis.Cliente> Clientes { get; set; }

        public DbSet<RazorPagesIgnis.Tecnico> Tecnicos { get; set; }

        public DbSet<RazorPagesIgnis.Solicitud> Solicitudes { get; set; }

        public DbSet<RazorPagesIgnis.Proyecto> Proyectos { get; set; }

        public DbSet<RazorPagesIgnis.Rol> Roles { get; set; }

        public DbSet<RazorPagesIgnis.TecnicoSolicitud> TecnicoSolicitudes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TecnicoSolicitud>().ToTable("TecnicoSolicitud")
                 .HasKey(a => new { a.tecnicoID, a.solicitudID });
        }

    }
}