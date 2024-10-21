using FoxFood.Dominio.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FoxFood.Data.Mapping
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa", "dbo");
            builder.HasIndex(e => e.IdUsuario, "Ref1956");

            builder.HasKey(e => e.Id).HasName("PK15");

            builder.Property(e => e.Id)
                 .ValueGeneratedOnAdd()
                 .HasColumnName("id");

            builder.Property(e => e.Bairro)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("bairro");

            builder.Property(e => e.Celular)
                .HasMaxLength(10)
                .HasColumnName("celular");

            builder.Property(e => e.Cep).HasMaxLength(25)
                 .HasColumnName("cep");

            builder.Property(e => e.Cnpj).HasMaxLength(20)
                 .HasColumnName("cnpj");

            builder.Property(e => e.Email).HasMaxLength(10)
                .HasColumnName("email");

            builder.Property(e => e.Endereco)
                .HasMaxLength(100)
                .HasColumnName("endereco");

            builder.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            builder.Property(e => e.NomeFantasia)
                .HasMaxLength(10)
                .HasColumnName("nomeFantasia");

            builder.Property(e => e.Numero).HasColumnName("numero");

            builder.Property(e => e.RazacaoSocial)
                .HasMaxLength(100)
                .HasColumnName("razacaoSocial");
        }
    }

}