using Microsoft.EntityFrameworkCore;
using Usuario.Data.EntityConfiguration;
using Dominio = Usuarios.Dominio.Models;

namespace Usuario.Data.Context
{
    public class BancoDadosContext : DbContext
    {
        public BancoDadosContext(DbContextOptions<BancoDadosContext> options) : base(options)
        {
        }

        public virtual DbSet<Dominio.Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuariosConfig());
        }
    }
}
