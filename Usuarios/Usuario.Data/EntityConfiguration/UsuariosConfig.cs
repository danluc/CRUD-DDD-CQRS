using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio = Usuarios.Dominio.Models;

namespace Usuario.Data.EntityConfiguration
{
    public class UsuariosConfig : IEntityTypeConfiguration<Dominio.Usuario>
    {
        public void Configure(EntityTypeBuilder<Dominio.Usuario> builder)
        {
            builder.ToTable("USUARIOS");

            builder.Property(p => p.Id)
               .HasColumnType("Int")
               .IsRequired()
               .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(p => p.Sobrenome)
                .HasMaxLength(200);

            builder.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Escolaridade)
               .HasColumnType("Int")
               .IsRequired();

            builder.Property(p => p.DataNascimento)
               .HasColumnType("DateTime")
               .IsRequired();
        }
    }
}