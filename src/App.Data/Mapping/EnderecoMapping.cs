using App.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mapping
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id); //Definindo chave primaria

            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)"); //Para usar o atributo HasColumnType temos que baixa o package  Install-Package Microsoft.EntityFrameworkCore.Relational

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasColumnType("varchar(1000)"); //Para usar o atributo HasColumnType temos que baixa o package  Install-Package Microsoft.EntityFrameworkCore.Relational

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasColumnType("varchar(100)"); //Para usar o atributo HasColumnType temos que baixa o package  Install-Package Microsoft.EntityFrameworkCore.Relational

            builder.Property(p => p.Cidade)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(p => p.Bairro)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(p => p.Complemento)
               .IsRequired()
               .HasColumnType("varchar(15)");

            builder.Property(p => p.Estado)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.ToTable("Enderecos");
        }
    }
}
