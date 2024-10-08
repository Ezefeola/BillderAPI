using Billder.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Billder.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
