using App.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mapping
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id); //Definindo chave primaria

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)"); //Para usar o atributo HasColumnType temos que baixa o package  Install-Package Microsoft.EntityFrameworkCore.Relational

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)"); //Para usar o atributo HasColumnType temos que baixa o package  Install-Package Microsoft.EntityFrameworkCore.Relational

            // 1 : 1 => Fornecedores : Endereco  Relacionamento 1 para 1 entre fornecedores e enderecos
            builder.HasOne(f => f.Endereco) //Fornecedor tem um endereco
                .WithOne(e => e.Fornecedor); // Endereco tem um fornecedor

            // 1 : N => Fornecedores : Produtos  Relacionamento 1 para N entre fornecedores e produtos
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}
